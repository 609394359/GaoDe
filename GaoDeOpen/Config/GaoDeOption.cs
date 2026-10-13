/*
* ==============================================================================
*
* FileName: GaoDeOption.cs
* Created: 2026/7/21 15:45:38
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

namespace GaoDeOpen.Config
{
    /// <summary>
    /// 高德配置项
    /// </summary>
    public class GaoDeOption
    {
        private Dictionary<string, GaoDeOptionItem> _items { get; set; } = new Dictionary<string, GaoDeOptionItem>();

        public Dictionary<string, GaoDeOptionItem> Items => _items;
        public GaoDeOption AddItem(GaoDeOptionItem item)
        {
            return AddItem("default", item);
        }
        public GaoDeOption AddItem(string key, GaoDeOptionItem item)
        {
            if (_items == null) _items = new Dictionary<string, GaoDeOptionItem>();

            if (_items.ContainsKey(key)) _items[key] = item;
            else _items.Add(key, item);

            return this;
        }

        public GaoDeOptionItem GetItem(string key = "default")
        {
            if (_items == null)
                throw new Exception($"请先调用GaoDeSetup.AddGaoDe()方法进行初始化");

            if (!_items.ContainsKey(key))
                throw new Exception($"高德配置不存在[{key}]");

            return _items[key];
        }
    }

    public class GaoDeOptionItem
    {
        /// <summary>
        /// 商家Comid
        /// </summary>
        public string ComId { get; set; }
        /// <summary>
        /// 应用AppId
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 高德云店密钥KEY
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 开发者的appSecret
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 服务商模式必传，需传入品牌商的商户主体id
        /// </summary>
        public string AccessId { get; set; }

        /// <summary>
        /// 是否测试
        /// </summary>
        public bool IsTest { get; set; } = false;
    }
}
