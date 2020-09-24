using DotNetStudy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.MyOrdersModels
{
    public class ShowMyOrdersModels
    {
        public List<Order> Orders { get; set; }      
        /// <summary>
        /// 我的地址
        /// </summary>
        public List<MyAddress> MyAddress { get; set; }
    }
}
