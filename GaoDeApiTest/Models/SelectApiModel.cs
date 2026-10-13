/*
* ==============================================================================
*
* FileName: SelectApiModel.cs
* Created: 2026/8/7 11:49:34
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaoDeApiTest.Models
{
    [AddINotifyPropertyChangedInterface]
    public class SelectApiModel
    {
        public SelectApiModel()
        {

        }
        public SelectApiModel(string displayName, Type reqType)
        {
            DisplayName = displayName;
            if (reqType != null)
            {
                ApiKey = reqType.Name;
                ReqType = reqType;
            }
        }
        public SelectApiModel(string displayName, Type reqType, Type resType)
        {
            DisplayName = displayName;
            if (reqType != null)
            {
                ApiKey = reqType.Name;
                ReqType = reqType;
            }
            ResType = resType;
        }
        public SelectApiModel(string displayName, string apiKey, Type reqType, Type resType)
        {
            DisplayName = displayName;
            ApiKey = apiKey;
            ReqType = reqType;
            ResType = resType;
        }
        public string DisplayName { get; set; }

        public string ApiKey { get; set; }

        public Type ReqType { get; set; }

        public Type ResType { get; set; }
    }
}
