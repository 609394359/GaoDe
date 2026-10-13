/*
* ==============================================================================
*
* FileName: TimeInfoDTO.cs
* Created: 2026/7/22 9:43:50
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
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
    /// 时间模型
    /// </summary>
    public class TimeInfoDTO
    {
        /// <summary>
        /// 开始时间 (yyyy-MM-dd)
        /// </summary>
        [JsonPropertyName("startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTimeDate => ToolsUtil.DateParse(StartTime);

        /// <summary>
        /// 结束时间 (yyyy-MM-dd)
        /// </summary>
        [JsonPropertyName("endTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTimeDate => ToolsUtil.DateParse(EndTime);

        /// <summary>
        /// 每周可用时间（周）
        /// </summary>
        [JsonPropertyName("weekDays")]
        public List<int> WeekDays { get; set; }

        /// <summary>
        /// 开始时间 (HH:mm)
        /// </summary>

        [JsonPropertyName("startHour")]
        public string StartHour { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public TimeSpan? StartHourTime => ToolsUtil.TimeParse(StartHour);

        /// <summary>
        /// 结束时间 (HH:mm)
        /// </summary>
        [JsonPropertyName("endHour")]
        public string EndHour { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public TimeSpan? EndHourTime => ToolsUtil.TimeParse(EndHour);

        /// <summary>
        /// 描述
        /// </summary>
        [JsonPropertyName("desc")]
        public string Desc { get; set; }
    }
}
