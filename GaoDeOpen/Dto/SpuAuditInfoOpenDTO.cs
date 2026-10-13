/*
* ==============================================================================
*
* FileName: SpuAuditInfoOpenDTO.cs
* Created: 2026/7/22 11:09:04
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using GaoDeOpen.Utils;
using System.Text.Json.Serialization;

namespace GaoDeOpen.Dto
{
    /// <summary>
    /// 商品
    /// </summary>
    public class SpuAuditInfoOpenDTO
    {
        /// <summary>
        /// SPU ID
        /// </summary>
        [JsonPropertyName("spuId")]
        public string SpuId { get; set; }

        /// <summary>
        /// SPU 名称
        /// </summary>
        [JsonPropertyName("spuName")]
        public string SpuName { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        [JsonPropertyName("prodType")]
        public string ProdType { get; set; }

        /// <summary>
        /// 创建时间 (格式: yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [JsonPropertyName("gmtCreate")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? GmtCreateTime => ToolsUtil.DateTimeParse(GmtCreate);

        /// <summary>
        /// 更新时间 (格式: yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [JsonPropertyName("gmtModified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? GmtModifiedTime => ToolsUtil.DateTimeParse(GmtModified);

        /// <summary>
        /// 状态：1-草稿，2-待审核，3-已上架，4-已下架
        /// </summary>
        [JsonPropertyName("status")]
        public int? Status { get; set; }

        /// <summary>
        /// 售卖开始时间 (格式: yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [JsonPropertyName("salesPeriodStart")]
        public string SalesPeriodStart { get; set; }

        /// <summary>
        /// 售卖开始时间
        /// </summary>
        public DateTime? SalesPeriodStartTime => ToolsUtil.DateTimeParse(SalesPeriodStart);

        /// <summary>
        /// 售卖结束时间 (格式: yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [JsonPropertyName("salesPeriodEnd")]
        public string SalesPeriodEnd { get; set; }

        /// <summary>
        /// 售卖结束时间
        /// </summary>
        public DateTime? SalesPeriodEndTime => ToolsUtil.DateTimeParse(SalesPeriodEnd);

        /// <summary>
        /// SKU 列表
        /// </summary>
        [JsonPropertyName("skuList")]
        public List<SkuAuditInfoOpenDTO> SkuList { get; set; }

        /// <summary>
        /// 类目 ID
        /// </summary>
        [JsonPropertyName("categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        /// 类目名称
        /// </summary>
        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 媒体信息 (JSON 对象)
        /// </summary>
        [JsonPropertyName("media")]
        public MediaDTO Media { get; set; }
    }

    public class SkuAuditInfoOpenDTO
    {

        /// <summary>
        /// skuId
        /// </summary>
        [JsonPropertyName("skuId")]
        public string skuId { get; set; }

        /// <summary>
        /// 商品原价（分）
        /// </summary>
        [JsonPropertyName("priceOri")]
        public long PriceOri { get; set; }

        /// <summary>
        /// 商品原价（元）
        /// </summary>
        public decimal PriceOriDecimal => PriceOri / 100.0M;

        /// <summary>
        /// 商品售价（分）
        /// </summary>
        [JsonPropertyName("priceSale")]
        public long PriceSale { get; set; }

        /// <summary>
        /// 商品售价（元）
        /// </summary>
        public decimal PriceSaleDecimal => PriceSale / 100.0M;

        /// <summary>
        /// 库存
        /// </summary>
        [JsonPropertyName("stock")]
        public long? Stock { get; set; }
    }
}
