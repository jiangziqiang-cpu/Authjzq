using AutoMapper;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.MappingProfiles
{
    public class OrderMappingProfile: Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, PayOrderModer>();
            CreateMap<PayOrderModer, Order>();           
        }
           
          
    }
}
