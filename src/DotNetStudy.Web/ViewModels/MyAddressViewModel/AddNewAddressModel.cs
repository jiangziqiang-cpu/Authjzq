using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.MyAddressViewModel
{
    public class AddNewAddressModel
    {
        public int UserId { get; set; }
        //收货人
        public string Receiver { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AddressInfo { get; set; }
    }
}
