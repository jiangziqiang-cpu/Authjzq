using Alipay.AopSdk.Core.Domain;
using DotNetStudy.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Services
{
    public class OrderDetailSever
    {
        private readonly StudyDbContext _context;
        public OrderDetailSever(StudyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 根据订单Id查询订单详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<List<Models.OrderDetail>> GetOrderDetailByOrderId(int Id)
        {
            List<Models.OrderDetail> orderDetails = await _context.orderDetails.Where(m => m.OrderId == Id).ToListAsync();
            return orderDetails;
        }

    }
}
