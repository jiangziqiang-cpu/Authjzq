using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Models
{
    public class Address
    {

        public int Id { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }
        /// <summary>
        /// 收获地址
        /// </summary>
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 订单
        /// </summary>
        public Order Order { get; set; }
    }
}
