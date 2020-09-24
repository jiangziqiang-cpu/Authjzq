namespace DotNetStudy.Web.ViewModels.PayViewModels
{
    public class PayIndexModel
    {
        //商户订单号
        public string TradeNo { get; set; }
        //订单名称
        public string Subject { get; set; }
        //付款金额
        public string TotalAmount { get; set; }
        //商品描述
        public string ItemBody { get; set; }
    }
}
