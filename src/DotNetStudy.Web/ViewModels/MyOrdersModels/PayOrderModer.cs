namespace DotNetStudy.Web.ViewModels.MyOrdersModels
{
    public class PayOrderModer
    {
        public sbyte PaymentType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public int Id { get; set; }
        public string OrderNo { get; set; }

    }
}
