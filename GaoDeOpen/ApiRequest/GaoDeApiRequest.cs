/*
* ==============================================================================
*
* FileName: GaoDeApiRequest.cs
* Created: 2026/7/21 16:43:38
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using GaoDeOpen.Config;
using GaoDeOpen.Helpers;
using GaoDeOpen.Requests;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace GaoDeOpen.ApiRequest
{
    public class GaoDeApiRequest : IGaoDeApiRequest
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<GaoDeApiRequest> _logger;


        /// <summary>
        /// JSON 序列化配置（snake_case 命名）
        /// </summary>
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true,
        };

        public GaoDeApiRequest(IHttpClientFactory httpClientFactory, ILogger<GaoDeApiRequest> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// POST 请求（JSON Body）
        /// </summary>
        public async Task<TResponse> PostAsync<TRequest, TResponse>(GaoDeOption option, TRequest req, string optionKey = "default") where TRequest : GaoDeBaseReq
        {
            return await PostAsync<TRequest, TResponse>(option.GetItem(optionKey), req);
        }
        /// <summary>
        /// POST 请求（JSON Body）
        /// </summary>
        public async Task<TResponse> PostAsync<TRequest, TResponse>(GaoDeOptionItem optionItem, TRequest req) where TRequest : GaoDeBaseReq
        {
            return await PostAsync<TResponse>(req.Method, req, optionItem.AppId, optionItem.Key, optionItem.AppSecret, optionItem.IsTest, req.GetParams());
        }

        /// <summary>
        /// POST 请求（JSON Body）
        /// </summary>
        public async Task<TResponse> PostAsync<TResponse>(string method, object data, string appId, string key, string secret, bool isTest, Dictionary<string, string> others)
        {
            var utc_timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString(); //当前时间戳(毫秒)
            var version = "1.0";
            var charset = "UTF-8";
            var sign_type = "HMAC-SHA256";
            var biz_content = JsonSerializer.Serialize(data, JsonOptions);


            string endpoint = isTest ? "rest/openmp/devgw?key=" : "rest/openmp/gw?key=";

            endpoint = endpoint + key;

            // 1. 构建键值对数据
            var formData = new Dictionary<string, string>
            {
                { "utc_timestamp", utc_timestamp },
                { "version", version },
                { "charset", charset },
                { "method", method },
                { "app_id", appId },
                { "biz_content", biz_content },
            };

            var signSource = GetSignSource(formData);

            var sign = HmacHelper.SignBase64(signSource, Convert.FromBase64String(secret));
            formData.Add("sign_type", sign_type);
            formData.Add("sign", sign);

            if (others != null)
            {
                foreach (var item in others)
                {
                    formData.Add(item.Key, item.Value);
                }
            }

            // 2. 使用 FormUrlEncodedContent 打包（会自动转码并设置正确的 Content-Type）
            using var content = new FormUrlEncodedContent(formData);

            /// 请求响应
            GaoDeAop.ApiRequest?.Invoke(JsonSerializer.Serialize(new
            {
                formData,
                signSource
            }, JsonOptions));

            var httpClient = _httpClientFactory.CreateClient("GaoDeApi");

            try
            {
                var response = await httpClient.PostAsync(endpoint, content);
                return await HandleResponse<TResponse>(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "高德 API POST 请求异常: {Method}", method);
                throw;
            }
        }

        /// <summary>
        /// 处理响应并反序列化
        /// </summary>
        private async Task<TResponse> HandleResponse<TResponse>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            /// 记录响应
            GaoDeAop.ApiResponse?.Invoke(content);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("高德 API 错误响应: {Content}", content);
                throw new HttpRequestException($"高德 API 请求失败，HTTP 状态码: {response.StatusCode}");
            }

            return JsonSerializer.Deserialize<TResponse>(content, JsonOptions);
        }

        public string GetSignSource(Dictionary<string, string> dict)
        {
            // 使用 StringComparer.Ordinal 严格按 ASCII 码逐字递增排序
            var sortedDict = dict.OrderBy(kv => kv.Key, StringComparer.Ordinal)
                                 .ToDictionary(kv => kv.Key, kv => kv.Value);

            StringBuilder sb = new StringBuilder();
            // 输出结果
            foreach (var item in sortedDict)
            {
                sb.Append($"{item.Key}={item.Value}&");
            }

            return sb.ToString().TrimEnd('&');
        }

    }
}
