/*
* ==============================================================================
*
* FileName: EmptyInstanceContractResolver.cs
* Created: 2026/8/7 11:48:04
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace GaoDeApiTest.Models
{
    public class EmptyInstanceContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            // 如果是可写的属性
            if (property.Writable)
            {
                // 备份原有的 ValueProvider
                var innerValueProvider = property.ValueProvider;

                // 重新包装 ValueProvider
                property.ValueProvider = new EmptyInitializationValueProvider(innerValueProvider, property.PropertyType);
            }

            return property;
        }

        private class EmptyInitializationValueProvider : IValueProvider
        {
            private readonly IValueProvider _innerValueProvider;
            private readonly Type _propertyType;

            public EmptyInitializationValueProvider(IValueProvider innerValueProvider, Type propertyType)
            {
                _innerValueProvider = innerValueProvider;
                _propertyType = propertyType;
            }

            // 设置值时的拦截逻辑
            public void SetValue(object target, object value)
            {
                // 如果 JSON 中没有传这个属性（即值为 null）
                if (value == null)
                {
                    // 1. 如果是字符串，保持 null 或者 string.Empty (根据需求，这里保留null)
                    if (_propertyType == typeof(string))
                    {
                        _innerValueProvider.SetValue(target, null);
                        return;
                    }

                    // 2. 如果是数组类型 (例如 string[], int[])
                    if (_propertyType.IsArray)
                    {
                        var elementType = _propertyType.GetElementType();
                        var emptyArray = Array.CreateInstance(elementType, 0); // 创建长度为 0 的空数组
                        _innerValueProvider.SetValue(target, emptyArray);
                        return;
                    }

                    // 3. 如果是泛型集合 (例如 List<T>, IList<T>)
                    if (typeof(IEnumerable).IsAssignableFrom(_propertyType) && _propertyType.IsGenericType)
                    {
                        // 尝试创建该集合的实例（如果是接口如 IList，则创建 List）
                        Type instanceType = _propertyType;
                        if (_propertyType.IsInterface)
                        {
                            var genericArgs = _propertyType.GetGenericArguments();
                            instanceType = typeof(List<>).MakeGenericType(genericArgs);
                        }

                        try
                        {
                            var emptyCollection = Activator.CreateInstance(instanceType);
                            _innerValueProvider.SetValue(target, emptyCollection);
                            return;
                        }
                        catch { /* 忽略无法实例化的复杂抽象集合 */ }
                    }

                    // 4. 如果是普通复杂对象类型 (非基础类型，非值类型)
                    if (!_propertyType.IsValueType && _propertyType.MainIsClass())
                    {
                        try
                        {
                            // 递归：为这个子对象也 new 一个空对象
                            // 使用递归反序列化，能保证子对象内部的数组和对象也能被初始化
                            var emptyObject = JsonConvert.DeserializeObject("{}", _propertyType, new JsonSerializerSettings
                            {
                                ContractResolver = new EmptyInstanceContractResolver() // 传递自身解析器
                            });
                            _innerValueProvider.SetValue(target, emptyObject);
                            return;
                        }
                        catch { /* 忽略无法实例化的类，如没有无参构造函数的类 */ }
                    }
                }

                // 如果本来就有值，或者不符合上述条件，走默认逻辑
                _innerValueProvider.SetValue(target, value);
            }

            public object GetValue(object target)
            {
                return _innerValueProvider.GetValue(target);
            }
        }
    }

    // 辅助扩展方法
    public static class TypeExtensions
    {
        public static bool MainIsClass(this Type type)
        {
            return type.IsClass && type != typeof(string);
        }
    }
}
