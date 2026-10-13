/*
* ==============================================================================
*
* FileName: GaoDeService.cs
* Created: 2026/7/22 15:45:02
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using GaoDeOpen.ApiRequest;
using GaoDeOpen.Config;
using GaoDeOpen.Dto;
using GaoDeOpen.Requests;
using GaoDeOpen.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaoDeOpen.Services
{
    public class GaoDeService : IGaoDeService
    {
        private readonly ILogger<GaoDeService> _logger;
        private readonly IGaoDeApiRequest _apiRequest;
        private readonly GaoDeOption _option;
        private readonly IHttpClientFactory _httpClientFactory;

        public GaoDeService(ILogger<GaoDeService> logger, IGaoDeApiRequest apiRequest, GaoDeOption option, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _apiRequest = apiRequest;
            _option = option;
            _httpClientFactory = httpClientFactory;
        }


        public GaoDeOption Option { get { return _option; } }

        #region 门店

        /// <summary>
        /// 门店列表 — 查询门店信息
        /// </summary>
        public async Task<ShopApiSafeSearchRespDTO> ShopQuery(ShopApiSafeSearchReq request,string optionKey = "default")
        {
            return await ShopQuery(request, _option.GetItem(optionKey));
        }

        /// <summary>
        /// 门店列表 — 查询门店信息
        /// </summary>
        public async Task<ShopApiSafeSearchRespDTO> ShopQuery(ShopApiSafeSearchReq request, GaoDeOptionItem optionItem)
        {
            var result = await _apiRequest.PostAsync<ShopApiSafeSearchReq, ShopApiSafeSearchResp>(optionItem, request);
            CheckResponse(result);
            return result.Response.Data;
        }

        /// <summary>
        /// 所有门店列表
        /// </summary>
        public async Task<List<QueryShopRespDTO>> AllShopQuery(string optionKey = "default")
        {
            return await AllShopQuery(_option.GetItem(optionKey));
        }

        /// <summary>
        /// 所有门店列表
        /// </summary>
        public async Task<List<QueryShopRespDTO>> AllShopQuery(GaoDeOptionItem optionItem)
        {
            var request = new ShopApiSafeSearchReq()
            {
                Size = 100,
            };
            var list = new List<QueryShopRespDTO>();
            while (true)
            {
                var result = await _apiRequest.PostAsync<ShopApiSafeSearchReq, ShopApiSafeSearchResp>(optionItem, request);

                CheckResponse(result);

                if (result.Response.Data == null || result.Response.Data.QueryShopRespDTOList.Count <= 0)
                    return list;

                list.AddRange(result.Response.Data.QueryShopRespDTOList);

                if (result.Response.Data.TotalCount <= list.Count)
                    return list;

                request.Start += result.Response.Data.Count;
            }
        }
        #endregion

        #region 商品

        /// <summary>
        /// 商品列表
        /// </summary>
        public async Task<ItemListOpenDTO> BrandQuery(BrandQueryItemListReq request, string optionKey = "default")
        {
            return await BrandQuery(request, _option.GetItem(optionKey));
        }

        /// <summary>
        /// 商品列表
        /// </summary>
        public async Task<ItemListOpenDTO> BrandQuery(BrandQueryItemListReq request, GaoDeOptionItem optionItem)
        {
            var result = await _apiRequest.PostAsync<BrandQueryItemListReq, BrandQueryItemListResp>(optionItem, request);
            CheckResponse(result);
            return result.Response.Data;
        }

        /// <summary>
        /// 所有商品列表
        /// </summary>
        /// <param name="status">状态，1-未上架,2-审核中,3-已上架,4-已下架,5-待整改</param>
        /// <returns></returns>
        public async Task<List<SpuAuditInfoOpenDTO>> AllBrandQuery(int? status = 3, string optionKey = "default")
        {
            return await AllBrandQuery(_option.GetItem(optionKey), status);
        }

        /// <summary>
        /// 所有商品列表
        /// </summary>
        /// <param name="status">状态，1-未上架,2-审核中,3-已上架,4-已下架,5-待整改</param>
        /// <returns></returns>
        public async Task<List<SpuAuditInfoOpenDTO>> AllBrandQuery(GaoDeOptionItem optionItem, int? status = 3)
        {
            var request = new BrandQueryItemListReq()
            {
                PageNo = 1,
                PageSize = 100,
                Status = status
            };
            var list = new List<SpuAuditInfoOpenDTO>();
            while (true)
            {
                var result = await _apiRequest.PostAsync<BrandQueryItemListReq, BrandQueryItemListResp>(optionItem, request);

                CheckResponse(result);

                if (result.Response.Data == null || result.Response.Data.SpuAuditInfoList.Count <= 0)
                    return list;

                list.AddRange(result.Response.Data.SpuAuditInfoList);

                if (result.Response.Data.TotalSize <= list.Count)
                    return list;

                request.PageNo += 1;
            }
        }

        /// <summary>
        /// 商品详情
        /// </summary>
        public async Task<ItemDetailOpenDTO> BrandDetail(BrandQueryItemDetailReq request, string optionKey = "default")
        {
            return await BrandDetail(request, _option.GetItem(optionKey));
        }

        /// <summary>
        /// 商品详情
        /// </summary>
        public async Task<ItemDetailOpenDTO> BrandDetail(BrandQueryItemDetailReq request, GaoDeOptionItem optionItem)
        {
            var result = await _apiRequest.PostAsync<BrandQueryItemDetailReq, BrandQueryItemDetailResp>(optionItem, request);
            CheckResponse(result);
            return result.Response.Data;
        }

        #endregion

        #region 券码

        /// <summary>
        /// 券码查询 — 验券准备
        /// </summary>
        public async Task<CouponConsultDTO> CouponConsult(CouponConsultReq request, string optionKey = "default")
        {
            return await CouponConsult(request, _option.GetItem(optionKey));
        }

        /// <summary>
        /// 券码查询 — 验券准备
        /// </summary>
        public async Task<CouponConsultDTO> CouponConsult(CouponConsultReq request, GaoDeOptionItem optionItem)
        {
            if (string.IsNullOrWhiteSpace(request.RequestId)) request.RequestId = Guid.NewGuid().ToString();

            var result = await _apiRequest.PostAsync<CouponConsultReq, CouponConsultResp>(optionItem, request);
            CheckResponse(result);
            return result.Response.Data;
        }

        /// <summary>
        /// 券码核销
        /// </summary>
        public async Task<CouponUseDTO> CouponUse(CouponUseReq request, string optionKey = "default")
        {
            return await CouponUse(request, _option.GetItem(optionKey));
        }

        /// <summary>
        /// 券码核销
        /// </summary>
        public async Task<CouponUseDTO> CouponUse(CouponUseReq request, GaoDeOptionItem optionItem)
        {
            if (string.IsNullOrWhiteSpace(request.ComId)) request.ComId = optionItem.ComId;
            if (string.IsNullOrWhiteSpace(request.RequestId)) request.RequestId = Guid.NewGuid().ToString();

            var result = await _apiRequest.PostAsync<CouponUseReq, CouponUseResp>(optionItem, request);
            CheckResponse(result);
            return result.Response.Data;
        }

        /// <summary>
        /// 券码冲销-撤销
        /// </summary>
        public async Task<CouponReverseDTO> CouponReverse(CouponReverseReq request, string optionKey = "default")
        {
            return await CouponReverse(request, _option.GetItem(optionKey));
        }

        /// <summary>
        /// 券码冲销-撤销
        /// </summary>
        public async Task<CouponReverseDTO> CouponReverse(CouponReverseReq request, GaoDeOptionItem optionItem)
        {
            if (string.IsNullOrWhiteSpace(request.RequestId)) request.RequestId = Guid.NewGuid().ToString();

            var result = await _apiRequest.PostAsync<CouponReverseReq, CouponReverseResp>(optionItem, request);
            CheckResponse(result);
            return result.Response.Data;
        }

        #endregion


        #region 私有方法

        /// <summary>
        /// 检查响应结果，失败时抛出异常
        /// </summary>
        private void CheckResponse<T>(GaoDeBaseResp<T> response)
        {
            if (response == null || response.Response == null)
            {
                throw new GaoDeException("快手 API 返回数据为空");
            }

            // 检查 extra 层错误
            if (!response.Response.Success)
            {
                _logger.LogError($"高德 API 错误 [extra]: error_code={response.Response.Code}, " +
                                 $"description={response.Response.Msg} ");
                throw new GaoDeException(
                    $"高德API错误：{response.Response.Code}, " +
                    $"原因：{response.Response.Msg}", response.Response.Code);
            }

            if (response.Response.Data is GaoDeSubResp data)
            {
                // 检查 data 层错误
                if (!data.IsSuccess)
                {
                    _logger.LogError($"高德 API 错误 [data]: error_code={data.SubCode}, " +
                                     $"description={data.SubMsg}");
                    throw new GaoDeException(
                        $"高德API错误: {data.SubCode}, " +
                        $"原因：{data.SubMsg}", data.SubCode);
                }
            }

        }

        #endregion
    }
}
