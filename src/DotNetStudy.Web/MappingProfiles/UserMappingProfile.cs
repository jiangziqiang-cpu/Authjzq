using AutoMapper;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.ViewModels.AccountViewModels;

namespace DotNetStudy.Web.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterModel, User>();
            CreateMap<ProfileModel, User>();
            CreateMap<User, ProfileModel>();
            CreateMap<User, UpdatePasswordModel>();//显示出修改密码界面的信息
            CreateMap<UpdatePasswordModel, User>();//进行修改
            CreateMap<User, UploadAvatorModel>();
        }
    }
}
