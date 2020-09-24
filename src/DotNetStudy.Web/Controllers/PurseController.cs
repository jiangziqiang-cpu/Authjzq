using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alipay.AopSdk.AspnetCore;
using Alipay.AopSdk.Core;
using Alipay.AopSdk.Core.Domain;
using Alipay.AopSdk.Core.Request;
using Alipay.AopSdk.Core.Response;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using DotNetStudy.Web.ViewModels.PurseViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetStudy.Web.Controllers
{
    public class PurseController : WebControllerBase
    {
        private readonly PurseService _purseService;
        private readonly TradeService _tradeService;
        private readonly AlipayService _alipayService;
        private readonly AlipayPaymentService _alipayPaymentService;
        
        public PurseController(PurseService purseService,
            IServiceProvider serviceProvider,
             TradeService tradeService,
             AlipayService alipayService,
             AlipayPaymentService _alipayPaymentService)
            : base(serviceProvider)
        {
            _purseService = purseService;
            _tradeService = tradeService;
            _alipayService = alipayService;
            this._alipayPaymentService = _alipayPaymentService;
        }
        public async Task<IActionResult> Index()
        {
            if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
            {
                return Redirect("/Account/Login");
            }
            var user = await _purseService.GetInfoByUserIdAsync(Convert.ToInt32(userIdValue));
            var purse = Mapper.Map<PurseModel>(user);
            return View(purse);
        }
        public async Task<IActionResult> Recharge()
        {
            if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
            {
                return Redirect("/Account/Login");
            }
            var user = await _purseService.GetBlanaceByUserIdAsync(Convert.ToInt32(userIdValue));
            var purse = Mapper.Map<RechargeModel>(user);
            return View(purse);
        }

        
        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="model">充值的参数</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Recharge(RechargeModel model)
        {
            if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
            {
                return Redirect("/Account/Login");
            }
            var balance = await _purseService.GetBlanaceByUserIdAsync(Convert.ToInt32(userIdValue));
            //创建账单 
            var trade = _tradeService.Create(new Trade()
            {
                Amount = model.Amount,
                UserId = balance.Id,
                Remark = $"充值金额{model.Amount} 元",
                TradeType = TradeType.Purse
            });
            if (trade!=null)
            {              
               return Redirect(_alipayPaymentService.AlipayPayment(trade, Request.Host));
            }         
            //判断交易单是否存在

            return RedirectToAction(nameof(Index));
        }

      

     
    }
}
