/*
* ==============================================================================
*
* FileName: BrandQueryItemListRes.cs
* Created: 2026/7/22 10:00:11
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using GaoDeOpen.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GaoDeOpen.Responses
{
    /// <summary>
    /// 商品列表查询（品牌）
    /// https://y.amap.com/docs/feature/cb6nnl4mci7rzp7s
    /// </summary>
    public class BrandQueryItemListResp : GaoDeBaseResp<ItemListOpenDTO>
    {
    }
    
    public class ItemListOpenDTO
    {

        /// <summary>
        /// 商品总数
        /// </summary>
        [JsonPropertyName("totalSize")]
        public int TotalSize { get; set; }

        /// <summary>
        /// 商品列表
        /// </summary>
        [JsonPropertyName("spuAuditInfoList")]
        public List<SpuAuditInfoOpenDTO> SpuAuditInfoList { get; set; }
    }
    
}
