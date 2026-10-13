/*
* ==============================================================================
*
* FileName: GaoDeSetup.cs
* Created: 2026/8/7 10:03:36
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using GaoDeOpen.ApiRequest;
using GaoDeOpen.Config;
using GaoDeOpen.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaoDeOpen
{
    /// <summary>
    /// 高德服务注册
    /// </summary>
    public static class GaoDeSetup
    {
        /// <summary>
        /// 添加高德平台服务
        /// </summary>
        /// <param name="service"></param>
        /// <param name="option">配置项</param>
        public static void AddGaoDe(this IServiceCollection service, Action<GaoDeOption> action)
        {
            service.AddHttpClient("GaoDeApi", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://restapi.amap.com/");
            });

            GaoDeOption option = new GaoDeOption();
            if (action != null)
            {
                action.Invoke(option);
            }
            service.AddSingleton(option);

            service.AddScoped<IGaoDeApiRequest, GaoDeApiRequest>();
            service.AddScoped<IGaoDeService, GaoDeService>();
        }
    }
}
