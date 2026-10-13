/*
* ==============================================================================
*
* FileName: SingleProductDTO.cs
* Created: 2026/7/22 9:50:25
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

namespace GaoDeOpen.Dto
{

    /// <summary>
    /// 单品模型
    /// </summary>
    public class SingleProductDTO
    {
        /// <summary>
        /// 单品（服务）ID
        /// </summary>
        [JsonPropertyName("singleProductId")]
        public string SingleProductId { get; set; }

        /// <summary>
        /// 单品（服务）名称
        /// </summary>
        [JsonPropertyName("singleProductName")]
        public string SingleProductName { get; set; }

        /// <summary>
        /// 单品数量
        /// </summary>
        [JsonPropertyName("singleProductNumber")]
        public int? SingleProductNumber { get; set; }

        /// <summary>
        /// 单品单位
        /// </summary>
        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// 单品价格（分）
        /// </summary>
        [JsonPropertyName("singlePrice")]
        public long? SinglePrice { get; set; }

        /// <summary>
        /// 单品价格（元）
        /// </summary>
        public decimal? SinglePriceDecimal => SinglePrice == null ? null : SinglePrice / 100.0m;

        /// <summary>
        /// 总价值（分）
        /// </summary>
        [JsonPropertyName("price")]
        public long? Price { get; set; }

        /// <summary>
        /// 总价值（元）
        /// </summary>
        public decimal? PriceDecimal => Price == null ? null : Price / 100.0m;
    }
}
