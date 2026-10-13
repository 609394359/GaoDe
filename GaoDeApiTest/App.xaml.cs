using GaoDeOpen;
using GaoDeOpen.Config;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Windows;

namespace GaoDeApiTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Action<string> HttpResponse { get; set; } = null!;
        public static Action<string> HttpRequest { get; set; } = null!;

        // 暴露一个全局可访问的 ServiceProvider（可选，但有时候方便手动获取服务）
        public static IServiceProvider ServiceProvider { get; private set; }


        // 1. 为你的 Mutex 创建一个唯一的名称（建议使用 GUID 或独特的字符串）
        private const string MutexName = "Global\\GAODEAPITEST_2C8D2459-0858-4CD3-A78A-F08A8743D256";
        private static Mutex? _mutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            // 2. 尝试获取 Mutex 的所有权
            _mutex = new Mutex(true, MutexName, out bool isNewInstance);

            // 3. If 如果已经有另一个实例在运行，关闭当前实例
            if (!isNewInstance)
            {
                MessageBox.Show("该程序已经在运行中。", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);

                // 优雅地退出当前重复的实例
                Application.Current.Shutdown();
                return;
            }

            // 4. 如果是第一个实例，正常启动
            base.OnStartup(e);

            var settings = new JsonSerializerSettings
            {
                // 开启自动换行和缩进
                Formatting = Formatting.Indented,
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                // 顺便配置一下小驼峰命名（可选，符合前端/现代JSON规范）
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };

            JsonConvert.DefaultSettings = () => settings;

            // 1. 创建 ServiceCollection
            var serviceCollection = new ServiceCollection();

            // 2. 配置/注册你的服务
            ConfigureServices(serviceCollection);

            // 3. 构建 ServiceProvider
            ServiceProvider = serviceCollection.BuildServiceProvider();

            // 4. 从容器中获取 MainWindow 并显示
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // 5. 程序退出时，释放并销毁 Mutex
            if (_mutex != null)
            {
                _mutex.ReleaseMutex();
                _mutex.Dispose();
            }

            base.OnExit(e);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddGaoDe((option) => { });

            GaoDeAop.ApiRequest = (msg) =>
            {
                HttpRequest?.Invoke(msg);
            };

            GaoDeAop.ApiResponse = (msg) =>
            {
                HttpResponse?.Invoke(msg);
            };

            // 必须把窗口（Windows）本身也注册进容器
            services.AddTransient<MainWindow>();
        }
    }

}
