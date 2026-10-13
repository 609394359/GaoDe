/*
* ==============================================================================
*
* FileName: CouponConsultReq.cs
* Created: 2026/7/22 14:48:09
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
    /// 查询内部券券码详情
    /// https://y.amap.com/docs/feature/cpunemk9inq0qavk
    /// </summary>
    public class CouponConsultReq : GaoDeBaseReq
    {
        public override string Method => "amap.standard.coupon.consult";

        /// <summary>
        /// 请求 id
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// 高德门店id； 注意：高德门店ID正常带后缀，例如 2024123111077000000110980135|xiniu_xgc_bgc
        /// </summary>
        [JsonPropertyName("shopId")]
        public string ShopId { get; set; }

        /// <summary>
        /// 券码
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 高德门店 INTERNAL_SHOP 传三方门店ID场景，前置需要与在高德门店侧完成三方门店ID绑定，具体是否能使用三方门店核销接入时前置沟通确认
        /// </summary>
        [JsonPropertyName("shopIdType")]
        public string ShopIdType { get; set; } = "INTERNAL_SHOP";

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
            if (string.IsNullOrWhiteSpace(AccessId)) return null;
            return new Dictionary<string, string>() { { "access_id", AccessId }, { "access_type", AccessType } };
        }
    }
}
