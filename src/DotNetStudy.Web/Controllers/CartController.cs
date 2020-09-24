using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

namespace DotNetStudy.Web.Controllers
{
    public class CartController : WebControllerBase
    {

        private readonly GoodsService _goodsService;
        private readonly GoodTypeService _goodsTypeService;
        private readonly CartService _cartService;
        public CartController(GoodsService goodsService, GoodTypeService goodsTypeService, CartService cartService,
           IServiceProvider serviceProvider)
           : base(serviceProvider)
        {
            _goodsService = goodsService;
            _goodsTypeService = goodsTypeService;
            _cartService = cartService;
        }
        public IActionResult Index(int Goodsid)
        {
                      
            if (Request.Cookies["UserName"] != null&& Request.Cookies["UserId"] !=null)
            {
                int userId = Convert.ToInt32(Request.Cookies["UserId"]);
                var good = _goodsService.SelectByIdAsync(Goodsid);
                 var cart=Mapper.Map<Cart>(good);
                var  cartgoods =_cartService.GetByProductId(userId, Goodsid);
                Cart carts = new Cart();
                if (cartgoods != null)
                {
                    carts.Quantity += 1;
                }
                else
                {

                     //var goods = _goodsService.SelectByIdAsync(id);
                     //var shopping=Mapper.Map<Cart>(goods);
                     //ShoppingCart.Add(shopping);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
           
        }
    }
}
