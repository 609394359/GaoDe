using GaoDeApiTest.Helpers;
using GaoDeApiTest.Models;
using GaoDeOpen.Config;
using GaoDeOpen.Requests;
using GaoDeOpen.Responses;
using GaoDeOpen.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GaoDeApiTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowView _viewModel = new WindowView();
        private readonly IGaoDeService _gaoDeService;
        public MainWindow(IGaoDeService gaoDeService)
        {
            _gaoDeService = gaoDeService;
            InitializeComponent();

            DataContext = _viewModel;

            InitApiList();

            App.HttpRequest = SetApiReq;
            App.HttpResponse = SetApiRes;
        }


        private void InitApiList()
        {
            var list = new ObservableCollection<SelectApiModel>();
            list.Add(new SelectApiModel("请选择", null));
            list.Add(new SelectApiModel("店铺列表", typeof(ShopApiSafeSearchReq), typeof(ShopApiSafeSearchResp)));
            list.Add(new SelectApiModel("商品列表", typeof(BrandQueryItemListReq), typeof(BrandQueryItemListResp)));
            list.Add(new SelectApiModel("商品详情", typeof(BrandQueryItemDetailReq), typeof(BrandQueryItemDetailResp)));
            list.Add(new SelectApiModel("券码详情", typeof(CouponConsultReq), typeof(CouponConsultResp)));
            list.Add(new SelectApiModel("券码核销", typeof(CouponUseReq), typeof(CouponUseResp)));
            list.Add(new SelectApiModel("券码冲正", typeof(CouponReverseReq), typeof(CouponReverseResp)));

            this._viewModel.ApiModels = list;
        }
        private void SetApiReq(string msg)
        {
            this._viewModel.ApiReq = msg;
        }
        private void SetApiRes(string msg)
        {
            this._viewModel.ApiRes = msg;
        }

        private void Com_Api_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count == 0)
                return;

            var item = e.AddedItems[0] as SelectApiModel;

            SetApiParm(item);

            this._viewModel.SelectApiModel = item;
            this._viewModel.ApiReq = null;
            this._viewModel.ApiRes = null;
            this._viewModel.ApiOut = null;
        }

        private void SetApiParm(SelectApiModel model)
        {
            if (model.ReqType == null)
            {
                this._viewModel.ApiParm = "";
                return;
            }
            var info = ObjectHelper.CreateInstance(model.ReqType);

            this._viewModel.ApiParm = JsonConvert.SerializeObject(info);

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this._viewModel.SelectApiModel == null)
                return;

            await ApiInvoik();
        }
        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var thumb = sender as System.Windows.Controls.Primitives.Thumb;

            // 顺着视觉树往上找，或者直接找它的 TemplatedParent (即绑定此模板的 TextBox)
            if (thumb != null && thumb.TemplatedParent is TextBox textBox)
            {
                // 如果之前没有显式设置过 Height，实际高度要用 ActualHeight
                double currentHeight = textBox.Height;
                if (double.IsNaN(currentHeight))
                {
                    currentHeight = textBox.ActualHeight;
                }

                double newHeight = currentHeight + e.VerticalChange;

                // 限制最小高度，防止缩成一条线
                if (newHeight >= textBox.MinHeight)
                {
                    textBox.Height = newHeight;
                }
            }
        }

        // 注意：参数类型改成了 MouseWheelEventArgs
        private void TextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // 1. 寻找 TextBox 内部自带的 ScrollViewer
                // 这样可以让 TextBox 优先滚自己的内容
                if (e.Delta > 0)
                {
                    textBox.LineUp();
                }
                else
                {
                    textBox.LineDown();
                }

                // 2. 【核心】拦截事件，阻止它向外冒泡给最外层的全局滚动条
                e.Handled = true;
            }
        }

        private async Task ApiInvoik()
        {
            this.Btn_Exec.IsEnabled = false;
            try
            {
                if (this._viewModel.SelectApiModel.ReqType == null)
                {
                    this._viewModel.ApiOut = "";
                    return;
                }

                var info = JsonConvert.DeserializeObject(this._viewModel.ApiParm, this._viewModel.SelectApiModel.ReqType);

                // 3. 将 info 声明为 dynamic，运行时会自动找到 Call<TResponse> 并精准匹配 TResponse
                dynamic dynamicInfo = info;
                object result = null;

                var optionItem = GetOptionItem();

                switch (this._viewModel.SelectApiModel.ReqType)
                {
                    case Type t when t == typeof(ShopApiSafeSearchReq):
                        result = await _gaoDeService.ShopQuery(dynamicInfo, optionItem);
                        break;
                    case Type t when t == typeof(BrandQueryItemListReq):
                        result = await _gaoDeService.BrandQuery(dynamicInfo, optionItem);
                        break;
                    case Type t when t == typeof(BrandQueryItemDetailReq):
                        result = await _gaoDeService.BrandDetail(dynamicInfo, optionItem);
                        break;
                    case Type t when t == typeof(CouponConsultReq):
                        result = await _gaoDeService.CouponConsult(dynamicInfo, optionItem);
                        break;
                    case Type t when t == typeof(CouponUseReq):
                        result = await _gaoDeService.CouponUse(dynamicInfo, optionItem);
                        break;
                    case Type t when t == typeof(CouponReverseReq):
                        result = await _gaoDeService.CouponReverse(dynamicInfo, optionItem);
                        break;
                    default:
                        break;
                }
                this._viewModel.ApiOut = JsonConvert.SerializeObject(result);

            }
            catch (Exception ex)
            {
                this._viewModel.ApiOut = ex.ToString();
            }
            finally
            {
                this.Btn_Exec.IsEnabled = true;
            }
        }

        private GaoDeOptionItem GetOptionItem()
        {
            return new GaoDeOptionItem()
            {
                ComId = this._viewModel.Comid,
                AppId = this._viewModel.AppId,
                Key = this._viewModel.Key,
                AppSecret = this._viewModel.AppSecret,
                AccessId = this._viewModel.AccessId,
                IsTest = this._viewModel.IsTest
            };
        }

    }
}