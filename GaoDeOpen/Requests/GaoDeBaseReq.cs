/*
* ==============================================================================
*
* FileName: GaoDeBaseReq.cs
* Created: 2026/7/21 17:19:36
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

namespace GaoDeOpen.Requests
{
    public abstract class GaoDeBaseReq
    {
        /// <summary>
        /// 接口全限定名，即云店的SPI
        /// </summary>
        [JsonIgnore]
        public abstract string Method { get;}

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, string> GetParams()
        {
            return null;
        }
    }
}
