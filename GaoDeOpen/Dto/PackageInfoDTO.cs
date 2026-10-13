/*
* ==============================================================================
*
* FileName: PackageInfoDTO.cs
* Created: 2026/7/22 9:47:09
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
    /// 套餐信息模型
    /// </summary>
    public class PackageInfoDTO
    {
        /// <summary>
        /// 补充说明
        /// </summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 分组单品组合
        /// </summary>
        [JsonPropertyName("list")]
        public List<SingleProductGroupDTO> List { get; set; }

        /// <summary>
        /// 服务流程信息
        /// </summary>
        [JsonPropertyName("processList")]
        public List<ServiceProcessDTO> ProcessList { get; set; }
    }
}
