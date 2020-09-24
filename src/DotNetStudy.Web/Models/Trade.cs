using System;

namespace DotNetStudy.Web.Models
{
    /// <summary>
    /// 交易单   
    /// </summary>
    public class Trade
    {
        public int Id { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 交易单号
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 交易单状态
        /// </summary>
        public TradeStatus TradeStatus { get; set; }
        /// <summary>
        /// 交易单类型  订单支付单、充值支付单等
        /// </summary>
        public TradeType TradeType { get; set; }
        public int RelationId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        public int UserId { get; set; }

    }
}
