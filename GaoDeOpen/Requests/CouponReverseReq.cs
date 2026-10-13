/*
* ==============================================================================
*
* FileName: CouponReverseReq.cs
* Created: 2026/7/22 15:24:04
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
    /// 内部券冲正
    /// https://y.amap.com/docs/feature/kt20mtnlmf4xgegm
    /// </summary>
    public class CouponReverseReq : GaoDeBaseReq
    {
        public override string Method => "amap.standard.coupon.reverse";

        /// <summary>
        /// 外部请求号，支持英文字母和数字，由开发者自行定义（不允许重复，最长32位）
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// 冲正信息，仅支持同一订单下的批量核销
        /// </summary>
        [JsonPropertyName("reverseInfos")]
        public List<CouponReverseReverseInfo> ReverseInfos { get; set; }

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

    public class CouponReverseReverseInfo
    {
        /// <summary>
        /// 凭证核销流水id  有流水 id 时，优先按流水冲正券码
        /// </summary>
        [JsonPropertyName("useTransId")]
        public string UseTransId { get; set; }

        /// <summary>
        /// 同一批次核销的所有 凭证 id 不支持批量核销，只冲正部分 常规情况只有一个
        /// </summary>
        [JsonPropertyName("codeIds")]
        public List<string> CodeIds { get; set; }
    }
}
