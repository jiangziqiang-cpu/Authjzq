using Alipay.AopSdk.AspnetCore;
using Alipay.AopSdk.Core.Domain;
using Alipay.AopSdk.Core.Request;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using DotNetStudy.Web.ViewModels.PurseViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace DotNetStudy.Web.Controllers
{
    public class AlipayController : WebControllerBase
    {
        private readonly AlipayService _alipayService;
        private readonly TradeService _tradeService;
        private readonly PurseService _purseService;
        public AlipayController(IServiceProvider serviceProvider, AlipayService alipayService,
             TradeService tradeService,
             PurseService purseService) : base(serviceProvider)
        {
            _alipayService = alipayService;
            _tradeService = tradeService;
            _purseService = purseService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Notify()
        {
            /* 实际验证过程建议商户添加以下校验。
			1、商户需要验证该通知数据中的out_trade_no是否为商户系统中创建的订单号，
			2、判断total_amount是否确实为该订单的实际金额（即商户订单创建时的金额），
			3、校验通知中的seller_id（或者seller_email) 是否为out_trade_no这笔单据的对应的操作方（有的时候，一个商户可能有多个seller_id/seller_email）
			4、验证app_id是否为该商户本身。
			*/
            Dictionary<string, string> sArray = GetRequestPost();


            if (sArray.Count != 0)
            {
                bool flag = _alipayService.RSACheckV1(sArray);
                if (flag)
                {
                    //交易状态
                    //判断该笔订单是否在商户网站中已经做过处理
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //请务必判断请求时的total_amount与通知时获取的total_fee为一致的
                    //如果有做过处理，不执行商户的业务程序

                    //注意：
                    //退款日期超过可退款期限后（如三个月可退款），支付宝系统发送该交易状态通知
                    string trade_status = Request.Form["trade_status"];
                    /*
                     WAIT_BUYER_PAY	交易创建，等待买家付款
                    TRADE_CLOSED	未付款交易超时关闭，或支付完成后全额退款
                    TRADE_SUCCESS	交易支付成功       
                    TRADE_FINISHED	交易结束，不可退款
                     */
                    string outTradeNo = Request.Form["out_trade_no"];
                    //string tradeNo = Request.Form["trade_no"];
                    //string orderNo = Request.QueryString.ToString();

                    if (trade_status == "TRADE_SUCCESS")
                    {
                        // 完成订单的业务逻辑
                        var trade = _tradeService.FindByNo(outTradeNo);
                        if (trade != null)
                        {
                            if (trade.TradeStatus == TradeStatus.NotPay)
                            {
                               await  _tradeService.Complete(trade);                                                             
                            }
                        }
                        // 日志记录
                    }
                }
                else
                {
                    return Content("fail");
                }
            }
            return Content("fail");
        }
        /// <summary>
		/// 支付同步回调
		/// </summary>
		[HttpGet]
        public IActionResult Callback()
        {
            /* 实际验证过程建议商户添加以下校验。
			1、商户需要验证该通知数据中的out_trade_no是否为商户系统中创建的订单号，
			2、判断total_amount是否确实为该订单的实际金额（即商户订单创建时的金额），
			3、校验通知中的seller_id（或者seller_email) 是否为out_trade_no这笔单据的对应的操作方（有的时候，一个商户可能有多个seller_id/seller_email）
			4、验证app_id是否为该商户本身。
			*/
            Dictionary<string, string> sArray = GetRequestGet();

            if (System.IO.Directory.Exists(@"C:\Users\Administrator\Desktop\Pays") == false)//如果不存在就创建file文件夹
            {
                System.IO.Directory.CreateDirectory(@"C:\Users\Administrator\Desktop\Pays");
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Users\Administrator\Desktop\Pays\Recharge.txt", true))
            {
                foreach (var item in sArray)
                {
                    writer.WriteLine($"Key:{item.Key} Value:{item.Value}");
                }
            }
            if (sArray.Count != 0)
            {
                bool flag = _alipayService.RSACheckV1(sArray);
                if (flag)
                {
                    Console.WriteLine($"同步验证通过，订单号：{sArray["out_trade_no"]}");
                    ViewData["PayResult"] = "同步验证通过";
                }
                else
                {
                    Console.WriteLine($"同步验证失败，订单号：{sArray["out_trade_no"]}");
                    ViewData["PayResult"] = "同步验证失败";
                }
            }
            return View();
        }
        private Dictionary<string, string> GetRequestGet()
        {
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            ICollection<string> requestItem = Request.Query.Keys;
            foreach (var item in requestItem)
            {
                sArray.Add(item, Request.Query[item]);

            }
            return sArray;
        }
        private Dictionary<string, string> GetRequestPost()
        {
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            ICollection<string> requestItem = Request.Form.Keys;
            foreach (var item in requestItem)
            {
                sArray.Add(item, Request.Form[item]);
            }
            return sArray;
        }

       
         
    }
}
