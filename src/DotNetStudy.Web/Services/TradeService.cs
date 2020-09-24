using DotNetStudy.Web.Data;
using DotNetStudy.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Services
{
    public class TradeService
    {
        private readonly StudyDbContext _context;

        public TradeService(StudyDbContext context)
        {
            _context = context;

        }
        public Trade Create(Trade trade)
        {
            if (trade == null)
                throw new ArgumentNullException(nameof(trade));
            trade.No = NoGenerator.New("T");
            trade.TradeStatus = TradeStatus.NotPay;
            trade.CreationTime = DateTime.Now;
            _context.Trades.Add(trade);
            _context.SaveChanges();
            return trade;
        }
        public Trade FindByNo(string tradeNo)
        {
            if (tradeNo == null)
                throw new ArgumentNullException(nameof(tradeNo));
            return _context.Trades.FirstOrDefault(f => f.No == tradeNo);
        }
        public async Task Complete(Trade trade)
        {
            if (trade == null)
                throw new ArgumentNullException(nameof(trade));
            trade.TradeStatus = TradeStatus.Complete;
            switch (trade.TradeType)
            {
                case TradeType.Order:
                    //修改订单状态
                    var order = await _context.Orders.Where(m => m.Id == trade.RelationId).FirstOrDefaultAsync();
                    order.OrderStatus = OrderStatus.Pay;
                    _context.Orders.Update(order);
                    await _context.SaveChangesAsync();
                    break;
                case TradeType.Purse:
                    var purse = _context.Purses.FirstOrDefault(f => f.UserId == trade.UserId);
                    if (purse != null)
                    {
                        purse.Balance += trade.Amount;
                        _context.Purses.Update(purse);
                        _context.SaveChanges();
                    }
                    break;
                default:
                    break;
            }
              _context.Trades.Update(trade);
            await _context.SaveChangesAsync();
        }
    }
}
