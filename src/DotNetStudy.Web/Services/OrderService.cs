using DotNetStudy.Web.Data;
using DotNetStudy.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetStudy.Web.Services;

namespace DotNetStudy.Web.Services
{
    public class OrderService
    {
        private readonly StudyDbContext _context;
        private readonly UserService _userService;
        private readonly CartService _cartService;
        public OrderService(StudyDbContext context, UserService userService, CartService cartService)
        {
            _context = context;
            _userService = userService;
            _cartService = cartService;
        }
        /// <summary>
        /// 根据orderId查询order表
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderByOrderId(int orderId)
        {
            return await _context.Orders.Where(p => p.Id == orderId).FirstOrDefaultAsync();
        }
        /// <summary>
        /// 根据用户Id查询我的订单表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Order>> GetAllByUserId(int userId)
        {
            return await _context.Orders.Where(p => p.UserId == userId).ToListAsync();
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task CancelOfOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// 提交购物车订单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> SubmitAsync(Order order)
        {
            //添加订单
            _context.Orders.Add(order);
            foreach (var item in order.OrderDetails)
            {
                _context.orderDetails.Add(item);
            }
            _context.Addresses.Add(order.Address);
           int isOk= await _context.SaveChangesAsync();
            return isOk;
        }

        /// <summary>
        /// 根据用户拿到订单最大的主键
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<Order> GetAllByUserIdOrderByDesc(int userId)
        {
            return await _context.Orders.Where(p => p.UserId == userId).OrderByDescending(m => m.Id).FirstOrDefaultAsync();

        }
    }
}
