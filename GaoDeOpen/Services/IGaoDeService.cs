using GaoDeOpen.Config;
using GaoDeOpen.Dto;
using GaoDeOpen.Requests;
using GaoDeOpen.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaoDeOpen.Services
{
    public interface IGaoDeService
    {


        #region 门店

        /// <summary>
        /// 门店列表 — 查询门店信息
        /// </summary>
        Task<ShopApiSafeSearchRespDTO> ShopQuery(ShopApiSafeSearchReq request, string optionKey = "default");

        /// <summary>
        /// 门店列表 — 查询门店信息
        /// </summary>
        Task<ShopApiSafeSearchRespDTO> ShopQuery(ShopApiSafeSearchReq request, GaoDeOptionItem optionItem);

        /// <summary>
        /// 所有门店列表
        /// </summary>
        Task<List<QueryShopRespDTO>> AllShopQuery(string optionKey = "default");

        /// <summary>
        /// 所有门店列表
        /// </summary>
        Task<List<QueryShopRespDTO>> AllShopQuery(GaoDeOptionItem optionItem);

        #endregion

        #region 商品


        /// <summary>
        /// 商品列表
        /// </summary>
        Task<ItemListOpenDTO> BrandQuery(BrandQueryItemListReq request, string optionKey = "default");

        /// <summary>
        /// 商品列表
        /// </summary>
        Task<ItemListOpenDTO> BrandQuery(BrandQueryItemListReq request, GaoDeOptionItem optionItem);

        /// <summary>
        /// 所有商品列表
        /// </summary>
        /// <param name="status">状态，1-未上架,2-审核中,3-已上架,4-已下架,5-待整改</param>
        /// <returns></returns>
        Task<List<SpuAuditInfoOpenDTO>> AllBrandQuery(int? status = 3, string optionKey = "default");

        /// <summary>
        /// 所有商品列表
        /// </summary>
        /// <param name="status">状态，1-未上架,2-审核中,3-已上架,4-已下架,5-待整改</param>
        /// <returns></returns>
        Task<List<SpuAuditInfoOpenDTO>> AllBrandQuery(GaoDeOptionItem optionItem, int? status = 3);

        /// <summary>
        /// 商品详情
        /// </summary>
        Task<ItemDetailOpenDTO> BrandDetail(BrandQueryItemDetailReq request, string optionKey = "default");

        /// <summary>
        /// 商品详情
        /// </summary>
        Task<ItemDetailOpenDTO> BrandDetail(BrandQueryItemDetailReq request, GaoDeOptionItem optionItem);

        #endregion

        #region 券码

        /// <summary>
        /// 券码查询 — 验券准备
        /// </summary>
        Task<CouponConsultDTO> CouponConsult(CouponConsultReq request, string optionKey = "default");

        /// <summary>
        /// 券码查询 — 验券准备
        /// </summary>
        Task<CouponConsultDTO> CouponConsult(CouponConsultReq request, GaoDeOptionItem optionItem);

        /// <summary>
        /// 券码核销
        /// </summary>
        Task<CouponUseDTO> CouponUse(CouponUseReq request, string optionKey = "default");

        /// <summary>
        /// 券码核销
        /// </summary>
        Task<CouponUseDTO> CouponUse(CouponUseReq request, GaoDeOptionItem optionItem);

        /// <summary>
        /// 券码冲销-撤销
        /// </summary>
        Task<CouponReverseDTO> CouponReverse(CouponReverseReq request, string optionKey = "default");

        /// <summary>
        /// 券码冲销-撤销
        /// </summary>
        Task<CouponReverseDTO> CouponReverse(CouponReverseReq request, GaoDeOptionItem optionItem);

        #endregion
    }
}
