using DotNetStudy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.MyCart
{
    public class MyCart
    {

        public MyCart()
        {
            this.Carts = new List<Cart>();
            this.MyAddress = new List<MyAddress>();
        }
        /// <summary>
        /// 我的购物车集合
        /// </summary>
        public List<Cart> Carts { get; set; }
        /// <summary>
        /// 我的地址
        /// </summary>
        public List<MyAddress> MyAddress { get; set; }
    }
}
