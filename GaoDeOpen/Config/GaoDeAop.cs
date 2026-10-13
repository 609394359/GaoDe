/*
* ==============================================================================
*
* FileName: Aop.cs
* Created: 2026/8/7 11:16:55
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

namespace GaoDeOpen.Config
{
    public static class GaoDeAop
    {
        public static Action<string> ApiRequest { get; set; } = null!;
        public static Action<string> ApiResponse { get; set; } = null!;

    }
}
