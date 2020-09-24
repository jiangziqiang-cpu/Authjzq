using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Models
{
    public class MyAddress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Receiver { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AddressInfo { get; set; }
    }
}
