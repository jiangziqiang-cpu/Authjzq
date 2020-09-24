using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Models
{
    public class Order
    {
       
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId{get;set;}
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 商品总价
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// 订单信息集合
        /// </summary>
        public ICollection<OrderDetail> OrderDetails { get; set; }
        /// <summary>
        /// 收件地址
        /// </summary>
        public Address Address { get; set; }
    }
}
