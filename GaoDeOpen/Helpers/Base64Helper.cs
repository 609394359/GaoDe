/*
* ==============================================================================
*
* FileName: Base64Helper.cs
* Created: 2026/8/25 10:49:34
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaoDeOpen.Helpers
{
    /// <summary>
    /// Base64 编解码帮助类 (.NET 8)
    /// </summary>
    public static class Base64Helper
    {
        private static readonly Encoding DefaultEncoding = Encoding.UTF8;

        #region 标准 Base64 编码 / 解码

        /// <summary>
        /// 将普通字符串转换为 Base64 编码字符串
        /// </summary>
        public static string Encode(string plainText, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            var enc = encoding ?? DefaultEncoding;
            byte[] bytes = enc.GetBytes(plainText);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 将 Base64 编码字符串解码为普通字符串
        /// </summary>
        public static string Decode(string base64Text, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(base64Text))
                return string.Empty;

            byte[] bytes = Convert.FromBase64String(base64Text);
            var enc = encoding ?? DefaultEncoding;
            return enc.GetString(bytes);
        }

        /// <summary>
        /// 将字节数组转换为 Base64 编码字符串
        /// </summary>
        public static string Encode(ReadOnlySpan<byte> bytes)
        {
            if (bytes.IsEmpty)
                return string.Empty;

            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 将 Base64 编码转换为字节数组
        /// </summary>
        public static byte[] DecodeToBytes(ReadOnlySpan<char> base64Chars)
        {
            if (base64Chars.IsEmpty)
                return Array.Empty<byte>();

            return Convert.FromBase64String(base64Chars.ToString());
        }

        #endregion

        #region 安全解密 / 验证

        /// <summary>
        /// 尝试将 Base64 字符串解码为普通字符串
        /// </summary>
        public static bool TryDecode(string base64Text, out string result, Encoding encoding = null)
        {
            result = string.Empty;
            if (string.IsNullOrEmpty(base64Text))
                return false;

            try
            {
                byte[] bytes = Convert.FromBase64String(base64Text);
                var enc = encoding ?? DefaultEncoding;
                result = enc.GetString(bytes);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// 判断字符串是否为合法的 Base64 格式
        /// </summary>
        public static bool IsBase64String(ReadOnlySpan<char> base64Chars)
        {
            if (base64Chars.IsEmpty || base64Chars.Length % 4 != 0)
                return false;

            // 使用零分配的 TryFromBase64Chars 校验格式
            Span<byte> buffer = stackalloc byte[base64Chars.Length];
            return Convert.TryFromBase64Chars(base64Chars, buffer, out _);
        }

        #endregion

        #region URL 安全的 Base64 (UrlSafeBase64)

        /// <summary>
        /// 将字符串转换为 URL 安全的 Base64 格式 (替换 + / 为 - _ 并移除末尾 =)
        /// </summary>
        public static string EncodeUrlSafe(string plainText, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            string base64 = Encode(plainText, encoding);
            return base64.Replace('+', '-').Replace('/', '_').TrimEnd('=');
        }

        /// <summary>
        /// 将 URL 安全的 Base64 字符串解码为普通字符串
        /// </summary>
        public static string DecodeUrlSafe(string urlSafeBase64Text, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(urlSafeBase64Text))
                return string.Empty;

            string base64 = urlSafeBase64Text.Replace('-', '+').Replace('_', '/');

            // 补齐末尾的 '=' 占位符
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            return Decode(base64, encoding);
        }

        #endregion

        #region 高性能/零堆分配 转换 (Span/Buffer)

        /// <summary>
        /// 高性能编码：将 byte 转换为 Base64 字符写入 Span 中，避免垃圾回收
        /// </summary>
        public static bool TryEncodeToUtf8(ReadOnlySpan<byte> bytes, Span<byte> utf8Base64Destination, out int bytesWritten)
        {
            var status = System.Buffers.Text.Base64.EncodeToUtf8(bytes, utf8Base64Destination, out _, out bytesWritten);
            return status == OperationStatus.Done;
        }

        /// <summary>
        /// 高性能解码：从 UTF8 Base64 字符集解码写入 Span 中
        /// </summary>
        public static bool TryDecodeFromUtf8(ReadOnlySpan<byte> utf8Base64, Span<byte> destination, out int bytesWritten)
        {
            var status = System.Buffers.Text.Base64.DecodeFromUtf8(utf8Base64, destination, out _, out bytesWritten);
            return status == OperationStatus.Done;
        }

        #endregion
    }
}
