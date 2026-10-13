/*
* ==============================================================================
*
* FileName: GaoDeException.cs
* Created: 2026/7/21 16:18:36
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaoDeOpen
{
    /// <summary>
    /// 高德SDK异常类
    /// </summary>
    /// <param name="message"></param>
    //public class GaoDeException(string message) : Exception(message);

    public class GaoDeException: Exception
    {
        public GaoDeException(string message) : base(message)
        {
        }
        public GaoDeException(string message,string code) : base(message)
        {
            Code = code;
        }

        public string Code { get; set; }


    }
}
