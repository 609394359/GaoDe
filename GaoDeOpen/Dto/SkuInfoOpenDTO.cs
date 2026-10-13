/*
* ==============================================================================
*
* FileName: SkuInfoOpenDTO.cs
* Created: 2026/7/22 9:29:09
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using GaoDeOpen.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GaoDeOpen.Dto
{
    /// <summary>
    /// SKU 信息模型
    /// </summary>
    public class SkuInfoOpenDTO
    {
        /// <summary>
        /// skuId
        /// </summary>
        [JsonPropertyName("skuId")]
        public string SkuId { get; set; }

        /// <summary>
        /// sku名称
        /// </summary>
        [JsonPropertyName("skuName")]
        public string SkuName { get; set; }

        /// <summary>
        /// 商品原价（分）
        /// </summary>
        [JsonPropertyName("priceOri")]
        public long? PriceOri { get; set; }

        /// <summary>
        /// 商品原价（元）
        /// </summary>
        public decimal? PriceOriDecimal => PriceOri == null ? null : PriceOri / 100.0m;

        /// <summary>
        /// 商品售价（分）
        /// </summary>
        [JsonPropertyName("priceSale")]
        public long? PriceSale { get; set; }

        /// <summary>
        /// 商品售价（元）
        /// </summary>
        public decimal? PriceSaleDecimal => PriceSale == null ? null : PriceSale / 100.0m;

        /// <summary>
        /// 币种
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// 库存
        /// </summary>

        [JsonPropertyName("stock")]
        public long? Stock { get; set; }

        /// <summary>
        /// 是否支持库存 1-支持
        /// </summary>
        [JsonPropertyName("supportStock")]
        public int? SupportStock { get; set; }

        /// <summary>
        /// 套餐/套餐详情
        /// </summary>
        [JsonPropertyName("packageInfo")]
        public PackageInfoDTO PackageInfo { get; set; }
    }
}
