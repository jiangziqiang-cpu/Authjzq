using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using DotNetStudy.Web.ViewModels.PurseViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNetStudy.Web.Controllers
{
    public class MyOrderController : WebControllerBase
    {
        /// <summary>
        /// 订单服务
        /// </summary>
        private readonly OrderService _orderService;
        private readonly CartService _cartService;
        private readonly MyAddressService _myAddressService;
        private readonly PurseService _purseService;
        private readonly TradeService _tradeService;
        private readonly AlipayPaymentService _alipayPaymentService;




        public MyOrderController(
            OrderService orderService,
            MyAddressService myAddressService,
            CartService cartService,
            PurseService purseService,
            TradeService tradeService,
            IServiceProvider serviceProvider,
            AlipayPaymentService alipayPaymentService) : base(serviceProvider)
        {
            _orderService = orderService;
            _cartService = cartService;
            _myAddressService = myAddressService;
            _purseService = purseService;
            _tradeService = tradeService;
            _alipayPaymentService = alipayPaymentService;
        }
        /// <summary>
        /// 显示我的订单
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ShowMyOrders()
        {
            if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
            {
                return Redirect("/Account/Login");
            }//判断是否登录 没有的话就跳回登录页面
            var myOrders = await _orderService.GetAllByUserId(Convert.ToInt32(userIdValue));
            var myaddress = await _myAddressService.GetAllByUserIdAsync(Convert.ToInt32(userIdValue));
            ShowMyOrdersModels showMyOrdersModels = new ShowMyOrdersModels()
            {
                Orders = new List<Order>(),
                MyAddress = new List<MyAddress>(),
            };
            showMyOrdersModels.Orders = myOrders;
            showMyOrdersModels.MyAddress = myaddress;
            if (myOrders == null)//判断此用户是否存在订单 不存在返回未找到
            {
                return NotFound();
            }
            //var orders = Mapper.Map<List<ShowMyOrdersModels>>(myOrders);//映射到视图实体
            return View(showMyOrdersModels);
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CancelOfOrder(int OrderId)
        {
            if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
            {
                return Redirect("/Account/Login");
            }//判断是否登录 没有的话就跳回登录页面
            var myOrders = await _orderService.GetOrderByOrderId(OrderId);
            if (myOrders == null)//判断订单是否存在 
            {
                return NotFound();
            }
            myOrders.OrderStatus = OrderStatus.CancelPay;
            await _orderService.CancelOfOrder(myOrders);
            return RedirectToAction(nameof(ShowMyOrders));
        }

        /// <summary>
        /// 提交购物车生成订单
        /// </summary>
        /// <param name="userid">用户</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Submit(int MyAddressId)
        {
            if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
            {
                //return Redirect("/Account/Login");
            }//判断是否登录 没有的话就跳回登录页面
            var carts = await _cartService.GetDisticByUserId(Convert.ToInt32(userIdValue));//根据用户Id拿到还没生成的购物车订单
            var myAddres = await _myAddressService.GetByIdAsync(Convert.ToInt32(MyAddressId));
            if (carts.Count <= 0)
            {
                return RedirectToAction("MyCart","Goods");
            }
            var order = new Order()
            {
                OrderNo = NoGenerator.New("O"),//订单编号
                UserId = Convert.ToInt32(userIdValue),
                OrderDetails = new List<OrderDetail>(),
                Amount = carts.Sum(s => s.Quantity * s.UnitPrice),
                OrderStatus = OrderStatus.Nopay
            };
            foreach (var item in carts)//循环取值生成订单 订单详情 和地址
            {
                OrderDetail orderDetail = new OrderDetail();
                //orderDetail.OrderId = Convert.ToInt32(maxOrderId?.Id + 1);
                orderDetail.ProductId = item.ProductId;//商品Id
                orderDetail.ProductName = item.ProductName;
                orderDetail.Quantity = item.Quantity;
                orderDetail.UnitPrice = item.UnitPrice;
                order.OrderDetails.Add(orderDetail);
            }
            order.Address = new Address()
            {
                Consignee = myAddres.Receiver,
                DeliveryAddress = myAddres.Address,
                PhoneNumber = myAddres.Phone,
            };         
            int isOk = await _orderService.SubmitAsync(order);
            if (isOk > 0)//判断订单是否生成成功
            {
                await _cartService.RemoveAllByUserId(Convert.ToInt32(userIdValue));
            }
            return RedirectToAction(nameof(ShowMyOrders));
        }

        /// <summary>
        /// 订单支付界面
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> PayOrder(int id)
        {
            if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
            {
                return Redirect("/Account/Login");
            }
            //订单
            var model = new PayOrderModer();
            var order = await _orderService.GetOrderByOrderId(id);
            if (order == null)
                return NotFound();
            //model.Id = order.Id;
            //model.Amount = order.Amount;
            //model.OrderNo = order.OrderNo;
            model = Mapper.Map<PayOrderModer>(order);
            //钱包
            var user = await _purseService.GetBlanaceByUserIdAsync(Convert.ToInt32(userIdValue));
            model.Balance = user.Balance;
            return View(model);
        }

        /// <summary>
        /// 提交订单支付
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PayOrder(PayOrderModer model)
        {
            //创建账单 
            var order = await _orderService.GetOrderByOrderId(model.Id);
            if (order == null)
                return NotFound();
            var trade = _tradeService.Create(new Trade()
            {
                Amount = order.Amount,
                UserId = UserId,
                Remark = $"支付金额{model.Amount} 元",
                TradeType = TradeType.Order,
                RelationId = order.Id
            });
            if (trade != null)
            {
                switch (model.PaymentType)
                {
                    case 0://微信
                        break;
                    case 1://支付宝
                        return Redirect(_alipayPaymentService.AlipayPayment(trade, Request.Host));
                    case 2://余额
                        var balance = await _purseService.GetBlanaceByUserIdAsync(UserId);
                        if (balance.Balance >= 0 && balance.Balance >= model.Amount)
                        {
                            
                            balance.Balance -= model.Amount;
                            await _purseService.UpdatePurseAsync(balance);
                            await _tradeService.Complete(trade);
                        }
                        else
                        {
                            return Content("余额不足请充值!");
                        }
                        break;
                    default:
                        break;
                }
            }
            //return RedirectToAction(nameof(PayOrder)) ;
            return RedirectToAction(nameof(ShowMyOrders)) ;
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        /// <returns></returns>
        public string RandomOrderNo()
        {
            var newFileName = DateTime.Now.ToString("yyyyMMdd");
            string[] num = {"A", "B","C", "D", "E", "F", "G", "H", "I",
                "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
                "U", "V", "W", "X", "Y","Z" };
            StringBuilder ranDowNum = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                Random random = new Random();
                int ranDowInt = random.Next(0, num.Length);
                ranDowNum.Append(num[ranDowInt]);
            }
            return newFileName + ranDowNum.ToString();
        }

        public async Task<IActionResult> BalancePayment()
        {

            return View();
        
        }
    }
}

