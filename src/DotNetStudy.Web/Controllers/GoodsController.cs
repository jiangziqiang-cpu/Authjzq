using System;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using DotNetStudy.Web.ViewModels.GoodsViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;

namespace DotNetStudy.Web.Controllers
{
    public class GoodsController : WebControllerBase
    {
        private readonly GoodsService _goodsService;
        private readonly GoodTypeService _goodsTypeService;
        private readonly CartService _cartService;
        private readonly GoodsImgaeService _goodsImgaeService;
        /// <summary>
        /// 我的地址服务
        /// </summary>
        private readonly MyAddressService _myAddressService;
        public GoodsController(GoodsService goodsService, GoodTypeService goodsTypeService, CartService cartService, MyAddressService myAddressService, GoodsImgaeService goodsImgaeService,
            IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _goodsService = goodsService;
            _goodsTypeService = goodsTypeService;
            _cartService = cartService;
            _myAddressService = myAddressService;
            _goodsImgaeService = goodsImgaeService;
        }

        public IActionResult Index()
        {
            if (Request.Cookies["UserName"] !=null&& Request.Cookies["UserId"] !=null)
            {
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
            
        }
        //[HttpPost]
        public async Task<IActionResult> ShowGoods()
        {

            var goods = await _goodsService.SelectAllAsync();
            var goodsImgae = await _goodsImgaeService.SelectAllAsync();
            var goodsModel = Mapper.Map<List<ShowGoodsModel>>(goods);

            var all = from g in goods
                      join t in goodsImgae on new { g.GoodsId } equals new { t.GoodsId }
                      select t;
            return View(all.ToList());
        }


        public async Task<IActionResult> ManagementGoods()
        {
            var goods = await _goodsService.SelectAllAsync();
            var goodsImgae = await _goodsImgaeService.SelectAllAsync();
            var all = from g in goods
                      join t in goodsImgae on new { g.GoodsId } equals new { t.GoodsId }
                      select t;
            return View(all.ToList());
        }

        public async Task<IActionResult> GoodsDetail(int id)
        {
            var goods = await _goodsService.SelectByIdAsync(id);
            var goodModel= Mapper.Map<ShowGoodsModel>(goods);
            return View(goodModel);
        }
        public async Task<IActionResult> AddGoods()
        {
           
            var goodsType = await _goodsTypeService.SelectAllAsync();
            List<GoodsType> lists = goodsType;
            // var list= Mapper.Map<List<GoodsTypeModel>>(goodsType);
            ViewBag.GoodType = lists;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGoods(ShowGoodsModel model)
        {

            var goods = Mapper.Map<Goods>(model);
            //ViewData["GoodType"] = Mapper.Map<List<GoodsType>>(goodsType);                        
            await _goodsService.CreateAsync(goods);
            return RedirectToAction("ShowGoods");
        }

        public async Task<IActionResult> UpdateGoods(int id)
        {
            //await _goodsTypeService.SelectAllAsync();
            var goodsType = await _goodsTypeService.SelectAllAsync();
            List<GoodsType> lists = goodsType;
            // var list= Mapper.Map<List<GoodsTypeModel>>(goodsType);
            ViewBag.GoodType = lists;

            var goods = await _goodsService.SelectByIdAsync(id);
            var goodModel = Mapper.Map<ShowGoodsModel>(goods);
            return View(goodModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGoods(ShowGoodsModel model)
        {
            if (ModelState.IsValid)
            {
                var goods = Mapper.Map<Goods>(model);
                await _goodsService.UpdateAsync(goods);
            }
            else
            {
                ModelState.AddModelError("", "");
                return View();
            }
            return RedirectToAction("ShowGoods");
        }


        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public async Task<IActionResult> AddCart(int id)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["UserId"] != null)
            {
                int userId = Convert.ToInt32(Request.Cookies["UserId"]);
                var cartList = await _cartService.GetByUserId(userId);
                if (cartList.Any<Cart>(x => x.ProductId == id))
                {
                    Cart cart = cartList.Where(p => p.ProductId == id).FirstOrDefault();
                    cart.Quantity += 1;
                    await _cartService.UpdateCartGoods(cart.ProductId, cart.Quantity);
                    //cartList = await _cartService.GetByUserId(userId);
                }
                else
                {
                    var good = await _goodsService.SelectByIdAsync(id);
                    Cart c = new Cart();
                    c.ProductId = good.GoodsId;
                    c.UserId = Convert.ToInt32(Request.Cookies["UserId"]);
                    c.UnitPrice = Convert.ToInt32(good.Price);
                    c.Quantity = 1;
                    c.ProductName = good.GoodsName;
                    c.UserName = Request.Cookies["UserName"];
                    await _cartService.CreateAsync(c);
                    //cartList.Add(c);
                }
             
                return View("ShowGoods");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
                
        }
        //购物车
        public  async Task<IActionResult> Cart(int id)
        {
            // var cart = Mapper.Map<Cart>(good);
            if (Request.Cookies["UserName"] != null && Request.Cookies["UserId"] != null)
            {
                int userId = Convert.ToInt32(Request.Cookies["UserId"]);
                var cartList = await _cartService.GetByUserId(userId);
                if (cartList.Any<Cart>(x=>x.ProductId==id))
                {
                    Cart cart=cartList.Where(p=>p.ProductId==id).FirstOrDefault();
                    cart.Quantity += 1;
                    await _cartService.UpdateCartGoods(cart.ProductId,cart.Quantity);
                    cartList = await _cartService.GetByUserId(userId);
                }
                else
                {
                    var good = await _goodsService.SelectByIdAsync(id);
                    Cart c = new Cart();
                    c.ProductId = good.GoodsId;
                    c.UserId = Convert.ToInt32(Request.Cookies["UserId"]);
                    c.UnitPrice = Convert.ToInt32(good.Price);
                    c.Quantity = 1;
                    c.ProductName = good.GoodsName;
                    c.UserName = Request.Cookies["UserName"];
                    await _cartService.CreateAsync(c);
                    cartList.Add(c);
                }                                                                                                                                        
                return View(cartList.ToList());
               
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        /// <summary>
        /// 我的购物车
        /// </summary>
        /// <returns></returns>
        public  async Task<IActionResult> MyCart()
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["UserId"] != null)
            {
                 var   userId = Convert.ToInt32(Request.Cookies["UserId"]);
                 var  cartList=  await _cartService.GetByUserId(userId);
                var myaddress = await _myAddressService.GetAllByUserIdAsync(userId);
                ViewModels.MyCart.MyCart myCart = new ViewModels.MyCart.MyCart()
                {
                    Carts = cartList,
                    MyAddress= myaddress
                };
                return View(myCart);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }                
        }

        [HttpPost]
        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> RemoveAllCart()
        {
            var myCart = await _cartService.GetByUserId(UserId);
            //if (myCart == null || myCart.Count <= 0)//判断此用户下是否存在购物车
            //{
            //    return NotFound();
            //}
            await _cartService.RemoveAllByUserId(UserId);
            return Redirect(nameof(MyCart));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCart(int Id)
        {
            
            await _cartService.RemoveCartById(Id);
            return Redirect(nameof(MyCart));
        }
        
    }
}
