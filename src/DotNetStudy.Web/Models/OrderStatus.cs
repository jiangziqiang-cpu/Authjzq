using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Models
{
    public enum OrderStatus : sbyte
    {
        [Display(Name = "未支付")]
        Nopay = 0,//未支付
        [Display(Name = "已经支付")]
        Pay = 1,//已支付
        [Display(Name = "取消支付")]
        CancelPay = 2,//取消支付
    }
}
