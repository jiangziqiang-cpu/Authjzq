using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.MyOrdersModels
{
    public class OrderPayModels
    {
        public int UserId { get; set; }
        /// <summary>
        /// 0 微信 1支付宝 2余额
        /// </summary>
        public sbyte PaymentType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }

        public  string OrderNo { get; set; }
    }
}
