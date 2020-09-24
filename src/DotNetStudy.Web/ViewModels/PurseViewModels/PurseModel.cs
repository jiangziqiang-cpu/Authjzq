using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.PurseViewModels
{
    public class PurseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        //余额
        public decimal Balance { get; set; }
        //积分
        public int Integral { get; set; }
    }
}
