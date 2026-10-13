/*
* ==============================================================================
*
* FileName: BrandQueryItemListReq.cs
* Created: 2026/7/22 9:59:45
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
    /// 商品列表查询（品牌）
    /// https://y.amap.com/docs/feature/cb6nnl4mci7rzp7s
    /// </summary>
    public class BrandQueryItemListReq : GaoDeBaseReq
    {
        public override string Method => "amap.standard.commodity.brand.queryItemList";

        /// <summary>
        /// 分页页码（必填）
        /// </summary>
        [JsonPropertyName("pageNo")]
        public int PageNo { get; set; }

        /// <summary>
        /// 分页大小（必填）
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// 门店id
        /// </summary>
        [JsonPropertyName("shopId")]
        public string ShopId { get; set; }

        /// <summary>
        /// 商品类型, groupBuy-团购、voucher-代金券
        /// </summary>
        [JsonPropertyName("prodType")]
        public string ProdType { get; set; }

        /// <summary>
        /// 状态，1-未上架,2-审核中,3-已上架,4-已下架,5-待整改
        /// </summary>
        [JsonPropertyName("status")]
        public int? Status { get; set; }
    }
}
