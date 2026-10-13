/*
* ==============================================================================
*
* FileName: QueryShopRespDTO.cs
* Created: 2026/7/22 14:38:58
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
    /// 店铺
    /// </summary>
    public class QueryShopRespDTO
    {
        /// <summary>
        /// 店铺 ID
        /// </summary>
        [JsonPropertyName("shopId")]
        public string ShopId { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        [JsonPropertyName("shopName")]
        public string ShopName { get; set; }

        /// <summary>
        /// 店铺状态：1 为正常开店
        /// </summary>
        [JsonPropertyName("shopState")]
        public int? ShopState { get; set; }

        /// <summary>
        /// 店铺地址
        /// </summary>
        [JsonPropertyName("shopAddress")]
        public string ShopAddress { get; set; }

        /// <summary>
        /// 省编码
        /// </summary>
        [JsonPropertyName("provinceCode")]
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 省名称
        /// </summary>
        [JsonPropertyName("provinceName")]
        public string ProvinceName { get; set; }

        /// <summary>
        /// 市编码
        /// </summary>
        [JsonPropertyName("cityCode")]
        public string CityCode { get; set; }

        /// <summary>
        /// 市名称
        /// </summary>
        [JsonPropertyName("cityName")]
        public string CityName { get; set; }

        /// <summary>
        /// 区编码
        /// </summary>
        [JsonPropertyName("districtCode")]
        public string DistrictCode { get; set; }

        /// <summary>
        /// 区名称
        /// </summary>
        [JsonPropertyName("districtName")]
        public string DistrictName { get; set; }
    }
}
