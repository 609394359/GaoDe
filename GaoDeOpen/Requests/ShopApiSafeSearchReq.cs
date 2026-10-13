/*
* ==============================================================================
*
* FileName: ShopApiSafeSearchReq.cs
* Created: 2026/7/22 11:35:48
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GaoDeOpen.Requests
{
    /// <summary>
    /// 店铺信息搜索（服务商可用）
    /// https://y.amap.com/docs/feature/vfz4gfr8npee6tlq
    /// </summary>
    public class ShopApiSafeSearchReq : GaoDeBaseReq
    {
        public override string Method => "amap.standard.shop.apiSafeSearch";

        /// <summary>
        /// 调用来源；业务产品定义的（必填）
        /// </summary>
        [JsonPropertyName("source")]
        public string Source { get; set; }

        /// <summary>
        /// 开分页位置（0），游标 offset（必填）
        /// </summary>
        [JsonPropertyName("start")]
        public int Start { get; set; }

        /// <summary>
        /// 每页查询数量（必填）
        /// </summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }

        /// <summary>
        /// 1代表正常店铺（必填）
        /// </summary>
        [JsonPropertyName("shopState")]
        public int? ShopState { get; set; }

        /// <summary>
        /// 服务商模式必传，需传入品牌商的商户主体id
        /// </summary>
        [JsonIgnore]
        public string AccessId { get; set; }

        /// <summary>
        /// 服务商模式必传，传固定英文值：COM_ID
        /// </summary>
        [JsonIgnore]
        public string AccessType => "COM_ID";

        public override Dictionary<string, string> GetParams()
        {
            if(string.IsNullOrWhiteSpace(AccessId)) return null;
            return new Dictionary<string, string>() { { "access_id", AccessId }, { "access_type", AccessType } };
        }

    }
}
