/*
* ==============================================================================
*
* FileName: CouponReverseRes.cs
* Created: 2026/7/22 15:36:58
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
    /// <summary>
    /// 内部券冲正
    /// https://y.amap.com/docs/feature/kt20mtnlmf4xgegm
    /// </summary>
    public class CouponReverseResp : GaoDeBaseResp<CouponReverseDTO>
    {
    }

    public class CouponReverseDTO : GaoDeSubResp
    {
    }
}
