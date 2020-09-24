using AutoMapper;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.ViewModels.MyAddressViewModel;

namespace DotNetStudy.Web.MappingProfiles
{
    public class MyAddressMappingProfile:Profile
    {
        public MyAddressMappingProfile()
        {
            CreateMap<MyAddress, MyAddressModel>();
            CreateMap<AddNewAddressModel, MyAddress>();
            CreateMap<MyAddressModel, MyAddress>();
        }
    }
}
