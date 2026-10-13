/*
* ==============================================================================
*
* FileName: BrandItemDetailReq.cs
* Created: 2026/7/21 17:16:33
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
    /// 商品详情查询（品牌）
    /// https://y.amap.com/docs/feature/dstqhebw5mmwtkgk
    /// </summary>
    public class BrandQueryItemDetailReq: GaoDeBaseReq
    {
        public override string Method => "amap.standard.commodity.brand.queryItemDetail";

        /// <summary>
        /// spuId（必填）
        /// </summary>
        [JsonPropertyName("spuId")]
        public long SpuId { get; set; }
    }
}
