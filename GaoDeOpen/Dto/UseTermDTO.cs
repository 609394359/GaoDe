/*
* ==============================================================================
*
* FileName: UseTermDTO.cs
* Created: 2026/7/22 9:24:43
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using GaoDeOpen.Responses;
using GaoDeOpen.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GaoDeOpen.Dto
{
    /// <summary>
    /// 使用规则模型
    /// </summary>
    public class UseTermDTO
    {
        /// <summary>
        /// 规则有效期类型
        /// </summary>
        [JsonPropertyName("effectiveTimeType")]
        public int? EffectiveTimeType { get; set; }

        /// <summary>
        /// 有效期天数
        /// </summary>
        [JsonPropertyName("effectiveDay")]
        public int? EffectiveDays { get; set; }

        /// <summary>
        /// 有效期开始时间 (yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [JsonPropertyName("effectiveStartTime")]
        public string EffectiveStartTime { get; set; }

        /// <summary>
        /// 有效期开始时间
        /// </summary>
        public DateTime? EffectiveStartTimeTime=>ToolsUtil.DateTimeParse(EffectiveStartTime);

        /// <summary>
        /// 有效期结束时间 (yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [JsonPropertyName("effectiveEndTime")]
        public string EffectiveEndTime { get; set; }

        /// <summary>
        /// 有效期结束时间
        /// </summary>
        public DateTime? EffectiveEndTimeTime => ToolsUtil.DateTimeParse(EffectiveEndTime);

        /// <summary>
        /// 使用说明 "USER_PAY_CODE"；"TICKET_CODE"
        /// </summary>
        [JsonPropertyName("certificateMode")]
        public string CertificateMode { get; set; }

        /// <summary>
        /// 部分时间不可用
        /// </summary>
        [JsonPropertyName("dateLimitUse")]
        public List<TimeInfoDTO> DateLimitUse { get; set; }

        /// <summary>
        /// 部分时间可用
        /// </summary>
        [JsonPropertyName("dateUse")]
        public List<TimeInfoDTO> DateUse { get; set; }

        /// <summary>
        /// 是否预定/预约规则
        /// </summary>
        [JsonPropertyName("needReserve")]
        public bool? NeedReserve { get; set; }
    }
}
