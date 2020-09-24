using Alipay.AopSdk.AspnetCore;
using Alipay.AopSdk.Core.Domain;
using Alipay.AopSdk.Core.Request;
using Alipay.AopSdk.Core.Response;
using DotNetStudy.Web.Data;
using DotNetStudy.Web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Services
{
    public class AlipayPaymentService
    {
        /// <summary>
        /// 数据库操作服务
        /// </summary>
        private readonly StudyDbContext _context;
        /// <summary>
        /// 支付宝服务
        /// </summary>
        private readonly AlipayService _alipayService;

        public AlipayPaymentService(StudyDbContext _context, AlipayService _alipayService)
        {
            this._context = _context;
            this._alipayService = _alipayService;
        }

        /// <summary>
        /// 支付宝支付
        /// </summary>
        /// <param name="trade">交易单实体</param>
        /// <param name="LocalAddress">本地地址</param>
        /// <returns></returns>
        public string AlipayPayment(Trade trade, HostString LocalAddress)
        {

            // 组装业务参数model
            AlipayTradePagePayModel payModel = new AlipayTradePagePayModel
            {
                Body = trade.Remark,
                Subject = trade.Remark,
                TotalAmount = trade.Amount.ToString(),
                OutTradeNo = trade.No,
                ProductCode = "FAST_INSTANT_TRADE_PAY"
            };
            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
          
            // 设置同步回调地址
            request.SetReturnUrl($"http://{LocalAddress}/Alipay/Callback");
            // 设置异步通知接收地址
            request.SetNotifyUrl($"http://{LocalAddress}/Alipay/Notify");
            // 将业务model载入到request
            request.SetBizModel(payModel);
            AlipayTradePagePayResponse response = _alipayService.SdkExecute(request);
            //跳转支付宝支付
            return _alipayService.Options.Gatewayurl + "?" + response.Body;
        }
    }
}
