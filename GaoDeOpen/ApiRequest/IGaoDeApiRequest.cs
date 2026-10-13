using GaoDeOpen.Config;
using GaoDeOpen.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaoDeOpen.ApiRequest
{
    public interface IGaoDeApiRequest
    {
        /// <summary>
        /// POST 请求（JSON Body）
        /// </summary>
        Task<TResponse> PostAsync<TRequest, TResponse>(GaoDeOption option, TRequest req,string optionKey = "default") where TRequest : GaoDeBaseReq;

        /// <summary>
        /// POST 请求（JSON Body）
        /// </summary>
        Task<TResponse> PostAsync<TRequest, TResponse>(GaoDeOptionItem optionItem, TRequest req) where TRequest : GaoDeBaseReq;

        /// <summary>
        /// POST 请求（JSON Body）
        /// </summary>
        Task<TResponse> PostAsync<TResponse>(string method, object data, string appId, string key, string secret, bool isTest, Dictionary<string, string> others);
    }
}
