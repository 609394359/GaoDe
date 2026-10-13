/*
* ==============================================================================
*
* FileName: HmacHelper.cs
* Created: 2026/7/21 16:23:43
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GaoDeOpen.Helpers
{
    /// <summary>
    /// HMAC-SHA256
    /// </summary>
    public class HmacHelper
    {
        /// <summary>
        /// 使用 HMAC-SHA256 算法生成签名
        /// </summary>
        /// <param name="message">待签名的原始消息</param>
        /// <param name="secret">密钥</param>
        /// <returns>签名结果（Hex 格式）</returns>
        public static string SignHex(string message, string secret)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(secret);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            // .NET 6+ 推荐使用静态方法 HashData，内存开销更小且效率更高
            byte[] hashBytes = HMACSHA256.HashData(keyBytes, messageBytes);

            // 转为十六进制小写字符串 (如: "a3b2c1...")
            //return Convert.ToHexString(hashBytes).ToLowerInvariant();
            return Convert.ToHexString(hashBytes);
        }

        /// <summary>
        /// 生成 Base64 格式的签名（常用于 HTTP Header 鉴权）
        /// </summary>
        public static string SignBase64(string message, string secret)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(secret);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] hashBytes = HMACSHA256.HashData(keyBytes, messageBytes);

            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// 生成 Base64 格式的签名（常用于 HTTP Header 鉴权）
        /// </summary>
        public static string SignBase64(string message, byte[] keyBytes)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] hashBytes = HMACSHA256.HashData(keyBytes, messageBytes);

            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// 验证签名是否合法
        /// </summary>
        /// <param name="message">收到原始消息</param>
        /// <param name="secret">密钥</param>
        /// <param name="signatureToVerify">待验证的签名（Hex格式）</param>
        /// <returns>是否合法</returns>
        public static bool VerifyHex(string message, string secret, string signatureToVerify)
        {
            // 1. 用本地密钥对收到到的消息重新签名
            string computedSignature = SignHex(message, secret);

            // 2. 将字符串转为 byte 数组
            byte[] computedBytes = Encoding.UTF8.GetBytes(computedSignature);
            byte[] targetBytes = Encoding.UTF8.GetBytes(signatureToVerify);

            // 3. 使用固定时间比较（防止时序攻击）
            return CryptographicOperations.FixedTimeEquals(computedBytes, targetBytes);
        }
    }
}
