namespace DotNetStudy.Web.ViewModels.PurseViewModels
{
    public class RechargeModel
    {
        public int UserId { get; set; }
        public sbyte PaymentType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
}
