using AuthorityManagement.Web.ViewModels.Role;
using AutoMapper;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.MappingProfiles
{
    public class RoleMappingProfile:Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<List<Role>, List<ShowRole>>();
            CreateMap<List<ShowRole>, List<Role>>();
            CreateMap<AddAndEditRoleViewModels, Role>();
            CreateMap<Role, AddAndEditRoleViewModels>();

        }
    }
}
