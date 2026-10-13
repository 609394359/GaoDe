/*
* ==============================================================================
*
* FileName: ObjectHelper.cs
* Created: 2026/8/7 11:55:13
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using GaoDeApiTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaoDeApiTest.Helpers
{
    public static class ObjectHelper
    {
        public static object CreateInstance(Type type)
        {
            // 1. 如果是字符串，保持 null 或者 string.Empty (根据需求，这里保留null)
            if (type == typeof(string))
            {
                return "";
            }
            if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                return DateTime.Now;
            }
            // 2. 如果是数组类型 (例如 string[], int[])
            if (type.IsArray)
            {
                var elementType = type.GetElementType();
                var emptyArray = Array.CreateInstance(elementType, 1); // 创建长度为 0 的空数组
                emptyArray.SetValue(CreateInstance(elementType), 0);
                return emptyArray;
            }
            // 3. 如果是泛型集合 (例如 List<T>, IList<T>)
            if (typeof(IEnumerable).IsAssignableFrom(type) && type.IsGenericType)
            {
                // 获取集合内部的元素类型 (例如 List<User> 拿到 User)
                var elementType = type.GetGenericArguments()[0];
                // 尝试创建该集合的实例（如果是接口如 IList，则创建 List）
                Type instanceType = type;
                if (type.IsInterface)
                {
                    var genericArgs = type.GetGenericArguments();
                    instanceType = typeof(List<>).MakeGenericType(genericArgs);
                }

                try
                {
                    var emptyCollection = Activator.CreateInstance(instanceType);

                    // 3. 将默认子项添加到集合中
                    // 使用反射调用 List.Add(item) 方法
                    var addMethod = instanceType.GetMethod("Add");
                    if (addMethod != null)
                    {
                        addMethod.Invoke(emptyCollection, new[] { CreateInstance(elementType) });
                    }

                    return emptyCollection;
                }
                catch
                {
                    return null;
                }
            }

            // 4. 如果是普通复杂对象类型 (非基础类型，非值类型)
            if (!type.IsValueType && type.MainIsClass())
            {
                try
                {
                    // 递归：为这个子对象也 new 一个空对象
                    // 使用递归反序列化，能保证子对象内部的数组和对象也能被初始化
                    var emptyObject = JsonConvert.DeserializeObject("{}", type);

                    foreach (var property in type.GetProperties())
                    {
                        if (property.CanWrite)
                        {
                            var propertyType = property.PropertyType;
                            var defaultValue = property.GetValue(emptyObject);
                            var value = defaultValue ==null ? CreateInstance(propertyType) : defaultValue;
                            if (value != null)
                            {
                                try
                                {
                                    property.SetValue(emptyObject, value);
                                }
                                catch
                                { }
                            }
                        }
                    }

                    return emptyObject;
                }
                catch
                {
                    return null;
                }
            }

            return default;
        }
    }
}
