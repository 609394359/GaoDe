/*
* ==============================================================================
*
* FileName: WindowView.cs
* Created: 2026/8/7 11:49:54
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaoDeApiTest.Models
{

    [AddINotifyPropertyChangedInterface]
    public class WindowView
    {
        /// <summary>
        /// 商家Comid
        /// </summary>
        public string Comid { get; set; } = "2088531021318297";
        /// <summary>
        /// 应用AppId
        /// </summary>
        public string AppId { get; set; } = "202607210191381308";
        /// <summary>
        /// 高德云店密钥KEY
        /// </summary>
        public string Key { get; set; } = "44b90a72b810674fd7a305d0dfa0c156";
        /// <summary>
        /// 开发者的appSecret
        /// </summary>
        public string AppSecret { get; set; } = "hYXlYMS5zmm/pqPg1HCpC9CFu1GpipkKVuE0Z6UKzo4=";

        /// <summary>
        /// 服务商模式必传，需传入品牌商的商户主体id
        /// </summary>
        public string AccessId { get; set; }

        /// <summary>
        /// 是否测试
        /// </summary>
        public bool IsTest { get; set; } = true;

        public ObservableCollection<SelectApiModel> ApiModels { get; set; } = new ObservableCollection<SelectApiModel>();
        public string ApiParm { get; set; }
        public string ApiReq { get; set; }
        public string ApiRes { get; set; }
        public string ApiOut { get; set; }

        public SelectApiModel SelectApiModel { get; set; }

    }
}
