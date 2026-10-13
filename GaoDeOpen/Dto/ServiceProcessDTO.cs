/*
* ==============================================================================
*
* FileName: ServiceProcessDTO.cs
* Created: 2026/7/22 9:51:57
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
    /// 服务流程模型
    /// </summary>
    public class ServiceProcessDTO
    {
        /// <summary>
        /// 服务内容
        /// </summary>
        [JsonPropertyName("serviceContent")]
        public string ServiceContent { get; set; }

        /// <summary>
        /// 服务数量
        /// </summary>

        [JsonPropertyName("number")]
        public int? Number { get; set; }

        /// <summary>
        /// 数量单位
        /// </summary>

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// 补充说明
        /// </summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}
