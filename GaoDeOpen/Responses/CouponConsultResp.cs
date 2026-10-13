/*
* ==============================================================================
*
* FileName: CouponConsultRes.cs
* Created: 2026/7/22 14:58:37
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using GaoDeOpen.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GaoDeOpen.Responses
{
    /// <summary>
    /// 查询内部券券码详情
    /// https://y.amap.com/docs/feature/cpunemk9inq0qavk
    /// </summary>
    public class CouponConsultResp: GaoDeBaseResp<CouponConsultDTO>
    {
    }

    public class CouponConsultDTO : GaoDeSubResp
    {

        /// <summary>
        /// 高德订单号
        /// </summary>
        [JsonPropertyName("amapOrderId")]
        public string AmapOrderId { get; set; }

        /// <summary>
        /// 扫码券码信息
        /// </summary>
        [JsonPropertyName("codeInfo")]
        public CouponConsultCodeInfoDTO CodeInfo { get; set; }

        /// <summary>
        /// 订单下全量券码信息列表
        /// </summary>
        [JsonPropertyName("codeInfos")]
        public List<CouponConsultCodeInfoDTO> CodeInfos { get; set; }

        /// <summary>
        /// 高德商品 SKU ID
        /// </summary>
        [JsonPropertyName("skuId")]
        public string SkuId { get; set; }

        /// <summary>
        /// 高德商品 ID
        /// </summary>
        [JsonPropertyName("itemId")]
        public string ItemId { get; set; }

        /// <summary>
        /// 三方的商品 ID (仅在发品时填写了的会返回)
        /// </summary>
        [JsonPropertyName("outItemId")]
        public string OutItemId { get; set; }

        /// <summary>
        /// 商品类型：groupBuy(团购)、voucher(代金券)
        /// </summary>
        [JsonPropertyName("prodType")]
        public string ProdType { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonPropertyName("skuName")]
        public string SkuName { get; set; }

        /// <summary>
        /// 商品单份原价，单位分
        /// </summary>
        [JsonPropertyName("skuOriginAmount")]
        public long? SkuOriginAmount { get; set; }

        /// <summary>
        /// 商品单份售价，单位分
        /// </summary>
        [JsonPropertyName("skuSaleAmount")]
        public long? SkuSaleAmount { get; set; }
    }

    public class CouponConsultCodeInfoDTO
    {
        /// <summary>
        /// 凭证 ID
        /// </summary>
        [JsonPropertyName("codeId")]
        public string CodeId { get; set; }

        /// <summary>
        /// 凭证码值
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 凭证状态：GENERATED(可使用)、CONSUMED(已核销)、INVALID(已退款)
        /// </summary>
        [JsonPropertyName("codeStatus")]
        public string CodeStatus { get; set; }

        /// <summary>
        /// 券生效时间戳 (毫秒/秒级时间戳)
        /// </summary>
        [JsonPropertyName("effectTime")]
        public long EffectTime { get; set; }

        /// <summary>
        /// 券失效时间戳 (毫秒/秒级时间戳)
        /// </summary>
        [JsonPropertyName("expireTime")]
        public long ExpireTime { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        [JsonPropertyName("totalQuantity")]
        public int TotalQuantity { get; set; }

        /// <summary>
        /// 剩余可核销数量
        /// </summary>
        [JsonPropertyName("availableQuantity")]
        public int AvailableQuantity { get; set; }

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
        /// 实收金额：用户支付+平台优惠，单位分
        /// </summary>
        [JsonPropertyName("receiptAmount")]
        public long ReceiptAmount { get; set; }

        /// <summary>
        /// 实收金额（元）：用户支付 + 平台优惠
        /// </summary>
        public decimal ReceiptAmountDecimal => ReceiptAmount / 100.0m;
    }
}
