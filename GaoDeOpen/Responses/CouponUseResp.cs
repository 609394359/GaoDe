/*
* ==============================================================================
*
* FileName: CouponUseRes.cs
* Created: 2026/7/22 15:19:32
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

namespace GaoDeOpen.Responses
{
    /// <summary>
    /// 内部券券码核销
    /// https://y.amap.com/docs/feature/tmceozury7ch3mfp
    /// </summary>
    public class CouponUseResp : GaoDeBaseResp<CouponUseDTO>
    {
    }

    public class CouponUseDTO: GaoDeSubResp
    {

        /// <summary>
        /// 请求中的订单号
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// 核销信息
        /// </summary>
        [JsonPropertyName("useDetails")]
        public List<CouponUseDetailDTO> UseDetails { get; set; }
    }

    /// <summary>
    /// 核销信息
    /// </summary>
    public class CouponUseDetailDTO
    {
        /// <summary>
        /// 高德券码 ID
        /// </summary>
        [JsonPropertyName("codeId")]
        public string CodeId { get; set; }

        /// <summary>
        /// 券码
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 本 code 的核销次数
        /// </summary>
        [JsonPropertyName("useNum")]
        public int UseNum { get; set; }

        /// <summary>
        /// 核销流水号 (需要保存，冲正时使用)
        /// </summary>
        [JsonPropertyName("useTransId")]
        public string UseTransId { get; set; }

        /// <summary>
        /// 商家优惠，单位分
        /// </summary>
        [JsonPropertyName("merchantDiscount")]
        public long MerchantDiscount { get; set; }

        /// <summary>
        /// 商家优惠（元）
        /// </summary>
        public decimal MerchantDiscountDecimal => MerchantDiscount / 100.0m;

        /// <summary>
        /// 平台优惠，单位分
        /// </summary>
        [JsonPropertyName("platformDiscount")]
        public long PlatformDiscount { get; set; }

        /// <summary>
        /// 平台优惠（元）
        /// </summary>
        public decimal PlatformDiscountDecimal => PlatformDiscount / 100.0m;

        /// <summary>
        /// 实收金额：用户支付 + 平台优惠，单位分
        /// </summary>
        [JsonPropertyName("receiptAmount")]
        public long ReceiptAmount { get; set; }

        /// <summary>
        /// 实收金额（元）：用户支付 + 平台优惠
        /// </summary>
        public decimal ReceiptAmountDecimal => ReceiptAmount / 100.0m;
    }
}
