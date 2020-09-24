using AutoMapper;
using DotNetStudy.Web.Controllers;
using DotNetStudy.Web.ViewModels.MyOrderDetailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.MappingProfiles
{
    public class OrderDetailsMappingProfile: Profile
    {
        public OrderDetailsMappingProfile()
        {
            CreateMap<Models.OrderDetail, MyViewOrderDetail>();
            CreateMap<MyViewOrderDetail, Models.OrderDetail>();
        }
        
    }
}
