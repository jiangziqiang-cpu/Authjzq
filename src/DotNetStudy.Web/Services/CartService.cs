using DotNetStudy.Web.Data;
using DotNetStudy.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Services
{
    public class CartService
    {
        private readonly StudyDbContext _context;
        private readonly UserService _userService;
        
        //private readonly ProductService _productService;
        public CartService(StudyDbContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
            
        }
        /*添加到购物车AddToCart，根据userId和productId*/

        //添加商品
        public async Task CreateAsync(Cart cart)
        {
            var good = await GetByCartGood(cart.ProductId);
            
                _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            
        }


        public async Task<Cart> GetByCartGood(int goodsId)
        {
           return await _context.Carts.Where(p => p.ProductId == goodsId).FirstOrDefaultAsync();                       
        }

        /// <summary>
        /// 根据cartId删除物品
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public async Task<IActionResult> RemoveCartById(int cartId)
        {
            var cart = await _context.Carts.Where(p => p.Id == cartId).FirstOrDefaultAsync();
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
            return null;
        }
        /// <summary>
        /// 根据cartId修改商品数量
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateCart(int cartId, int quantity)
        {        
            var cart = await _context.Carts.Where
            (p => p.Id == cartId && p.Quantity == quantity).FirstOrDefaultAsync();
            if (cart != null)
            {
                _context.Carts.Update(cart);
            }
            return null;
        }

        /// <summary>
        /// 根据cartId修改商品数量
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateCartGoods(int goods, int quantity)
        {
            var cart = await _context.Carts.Where
            (p => p.ProductId == goods && p.Quantity == quantity).FirstOrDefaultAsync();
            if (cart != null)
            {
                _context.Carts.Update(cart);
            }
            await _context.SaveChangesAsync();
            return  null;
        }
        /// <summary>
        /// 根据userID查询整个集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Cart>> GetByUserId(int userId)
        {
            return await _context.Carts.Where(p => p.UserId == userId).ToListAsync();
        }

        /// <summary>
        /// 去掉已经生成的订单在进行查询
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Cart>> GetDisticByUserId(int userId)
        {
            var query =await  _context.Carts.Where( p => p.UserId == userId).ToListAsync();
            var queryList = from u in query
                            where !(from o in _context.orderDetails select o.ProductId).Contains(u.ProductId)
                            select u;
            return queryList.ToList();
        }
        /// <summary>
        /// 根据商品id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Cart> GetByProductId(int userId,int productId)
        {
            return await _context.Carts.Where(p => p.UserId == userId&&p.ProductId==productId).FirstOrDefaultAsync();
        }
        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IActionResult> RemoveAllByUserId(int userId)
        {
            var cart = await _context.Carts.Where(p => p.UserId == userId).FirstOrDefaultAsync();
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                _context.SaveChanges();
            }
            return null;
        }
    }
}
