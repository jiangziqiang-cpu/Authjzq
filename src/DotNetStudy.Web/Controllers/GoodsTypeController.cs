using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetStudy.Web.Controllers
{
    public class GoodsTypeController : WebControllerBase
    {

        private readonly GoodsService _goodsService;
        private readonly GoodTypeService _goodsTypeService;
        public GoodsTypeController(GoodsService goodsService, GoodTypeService goodsTypeService,
            IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _goodsService = goodsService;
            _goodsTypeService = goodsTypeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 展示所有商品分类
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ShowGoodsType()
        {
            var GoodsTypeList = await _goodsTypeService.SelectAllAsync();
            //var goods = Mapper.Map<List<GoodsTypeModel>>(GoodsTypeList);
            return View(GoodsTypeList.ToList());
        }

        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <returns></returns>
        public IActionResult AddGoodsType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGoodsType(GoodsType goodsType)
        {
            //var goods = Mapper.Map<GoodsType>(model);
            await _goodsTypeService.CreateAsync(goodsType);
            return RedirectToAction("ShowGoodsType", "GoodsType");
        }

        public async Task<IActionResult> UpdateGoodsType(int id)
        {
            var goodType = await _goodsTypeService.SelectByIdAsync(id);
            var goodTypeList = await _goodsTypeService.SelectAllAsync();
            ViewBag.GoodsTypeId = new SelectList(goodTypeList, "GoodsTypeId", "GoodsTypeName", goodType.GoodsTypeId);
            return View(goodType);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGoodsType(GoodsType goodsType)
        {

            //var goods = Mapper.Map<GoodsType>(model);
            await _goodsTypeService.UpdateAsync(goodsType);

            return RedirectToAction("ShowGoodsType");
        }
    }
}
