/*
* ==============================================================================
*
* FileName: GaoDeBaseRes.cs
* Created: 2026/7/21 17:23:54
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

namespace GaoDeOpen.Responses
{
    public class GaoDeBaseResp<T>
    {
        [JsonPropertyName("response")]
        public GaoDeBaseData<T> Response { get; set;}
    }
    /// <summary>
    /// 高德 API data 层公共字段
    /// </summary>
    public class GaoDeBaseData<T>
    {
        /// <summary>
        /// 状态码，详见<公共文档-网关公共错误码>
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [JsonPropertyName("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("data")]
        public T Data { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success => Code == "10000" || Code == "SUCCESS";
    }

    /// <summary>
    /// 有子状态的基类
    /// </summary>
    public class GaoDeSubResp
    {
        /// <summary>
        /// 错误子码 (见具体错误码表格)
        /// "subCode":"USE_TRANS_ALREADY_REVERSE","subMsg":"核销流水已冲正"
        /// </summary>
        [JsonPropertyName("subCode")]
        public string SubCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonPropertyName("subMsg")]
        public string SubMsg { get; set; }

        public bool IsSuccess => SubCode == "SUCCESS";
    }
}
