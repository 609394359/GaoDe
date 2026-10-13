/*
* ==============================================================================
*
* FileName: SingleProductGroupDTO.cs
* Created: 2026/7/22 9:48:53
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
    /// 单品分组模型
    /// </summary>
    public class SingleProductGroupDTO
    {
        /// <summary>
        /// 分组ID
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        [JsonPropertyName("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// 分组排序
        /// </summary>
        [JsonPropertyName("groupOrder")]
        public int? GroupOrder { get; set; }

        /// <summary>
        /// 分组可选择数量 (null表不限制，大于N则不可不选)
        /// </summary>
        [JsonPropertyName("selectNumber")]
        public int? SelectNumber { get; set; }

        /// <summary>
        /// 是否是多选分组 (true：可多选且不可复选，false：不可多选)
        /// </summary>
        [JsonPropertyName("repeatSelect")]
        public bool? RepeatSelect { get; set; }

        /// <summary>
        /// 菜单单品列表
        /// </summary>
        [JsonPropertyName("singleProductList")]
        public List<SingleProductDTO> SingleProductList { get; set; }
    }
}
