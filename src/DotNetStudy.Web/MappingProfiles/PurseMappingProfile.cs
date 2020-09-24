using AutoMapper;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.ViewModels.PurseViewModels;

namespace DotNetStudy.Web.MappingProfiles
{
    public class PurseMappingProfile : Profile
    {
        public PurseMappingProfile()
        {
            CreateMap<Purse, PurseModel>();
            CreateMap<PurseModel, Purse>();
            CreateMap<Purse, RechargeModel>();
            CreateMap<RechargeModel, Purse>();
        }
    }
}
