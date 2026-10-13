/*
* ==============================================================================
*
* FileName: ItemDetailOpenDTO.cs
* Created: 2026/7/22 9:23:43
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
    /// 商品/项目详情 OpenDTO
    /// </summary>
    public class ItemDetailOpenDTO
    {
        /// <summary>
        /// spuId
        /// </summary>
        [JsonPropertyName("spuId")]
        public string SpuId { get; set; }

        /// <summary>
        /// spu名称
        /// </summary>
        [JsonPropertyName("spuName")]
        public string SpuName { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        [JsonPropertyName("prodType")]
        public string ProdType { get; set; }

        /// <summary>
        /// 创建时间 yyyy-MM-dd HH:mm:ss
        /// </summary>
        [JsonPropertyName("gmtCreate")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? GmtCreateTime => ToolsUtil.DateTimeParse(GmtCreate);

        /// <summary>
        /// 修改时间 yyyy-MM-dd HH:mm:ss
        /// </summary>
        [JsonPropertyName("gmtModified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? GmtModifiedTime => ToolsUtil.DateTimeParse(GmtModified);

        /// <summary>
        /// 状态 1-未上架 2-审核中 3-已上架 4-已下架 5-已删除
        /// </summary>
        [JsonPropertyName("status")]
        public int? Status { get; set; }

        /// <summary>
        /// 售卖开始时间 yyyy-MM-dd HH:mm:ss
        /// </summary>
        [JsonPropertyName("salesPeriodStart")]
        public string SalesPeriodStart { get; set; }

        /// <summary>
        /// 售卖开始时间
        /// </summary>
        public DateTime? SalesPeriodStartTime => ToolsUtil.DateTimeParse(SalesPeriodStart);

        /// <summary>
        /// 售卖结束时间 yyyy-MM-dd HH:mm:ss
        /// </summary>
        [JsonPropertyName("salesPeriodEnd")]
        public string SalesPeriodEnd { get; set; }

        /// <summary>
        /// 售卖结束时间
        /// </summary>
        public DateTime? SalesPeriodEndTime => ToolsUtil.DateTimeParse(SalesPeriodEnd);

        /// <summary>
        /// 商品类目ID
        /// </summary>
        [JsonPropertyName("categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        /// 商品类目名称
        /// </summary>
        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 媒体信息
        /// </summary>
        [JsonPropertyName("media")]
        public MediaDTO Media { get; set; }

        /// <summary>
        /// 核销数据
        /// </summary>
        [JsonPropertyName("useTerm")]
        public UseTermDTO UseTerm { get; set; }

        /// <summary>
        /// sku列表
        /// </summary>
        [JsonPropertyName("skuList")]
        public List<SkuInfoOpenDTO> SkuList { get; set; }

        /// <summary>
        /// 适用门店/shop列表
        /// </summary>
        [JsonPropertyName("shopList")]
        public List<string> ShopList { get; set; }
    }

}
