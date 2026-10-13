/*
* ==============================================================================
*
* FileName: ShopApiSafeSearchRes.cs
* Created: 2026/7/22 11:35:52
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
    /// 店铺信息搜索（服务商可用）
    /// https://y.amap.com/docs/feature/vfz4gfr8npee6tlq
    /// </summary>
    public class ShopApiSafeSearchResp : GaoDeBaseResp<ShopApiSafeSearchRespDTO>
    {
    }
    public class ShopApiSafeSearchRespDTO
    {
        /// <summary>
        /// 总数
        /// </summary>
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        /// 本次查询条数
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }

        /// <summary>
        /// 店铺列表返回值
        /// </summary>
        [JsonPropertyName("queryShopRespDTOList")]
        public List<QueryShopRespDTO> QueryShopRespDTOList { get; set; }
    }
}
