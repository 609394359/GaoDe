/*
* ==============================================================================
*
* FileName: MediaDTO.cs
* Created: 2026/7/22 9:24:20
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
    /// 媒体资源模型
    /// </summary>
    public class MediaDTO
    {
        /// <summary>
        /// 头部url集
        /// </summary>
        [JsonPropertyName("headPicUrl")]
        public List<string> HeadPicUrl { get; set; }

        /// <summary>
        /// 图文详情
        /// </summary>
        [JsonPropertyName("picUrls")]
        public List<PicInfo> PicUrls { get; set; }
    }

    /// <summary>
    /// 图文详情
    /// </summary>
    public class PicInfo
    {
        /// <summary>
        /// 图片url列表
        /// </summary>
        [JsonPropertyName("pircUrl")]
        public List<string> PircUrl { get; set; }

        /// <summary>
        /// 图片描述
        /// </summary>
        [JsonPropertyName("desc")]
        public string Desc { get; set; }
    }
}
