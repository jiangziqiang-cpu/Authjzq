using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetStudy.Web.Services;
using DotNetStudy.Web.ViewModels.MyOrderDetailModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetStudy.Web.Controllers
{
    public class MyOrderDetails : WebControllerBase
    {
        private readonly OrderDetailSever _orderDetailSever;
        public MyOrderDetails(OrderDetailSever orderDetailSever,IServiceProvider serviceProvider):base(serviceProvider)
        {
            _orderDetailSever = orderDetailSever;
        }
        public async Task<IActionResult> MyOrderDetail(int Id)
        {
           var orderDetails = await _orderDetailSever.GetOrderDetailByOrderId(Id);
          List<MyViewOrderDetail> myViewOrderDetail= Mapper.Map<List<MyViewOrderDetail>>(orderDetails);
            return View(myViewOrderDetail);
        }


    }
}
