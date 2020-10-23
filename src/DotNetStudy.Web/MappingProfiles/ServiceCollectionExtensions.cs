using AuthorityManagement.Web.MappingProfiles;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetStudy.Web.MappingProfiles
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMappingProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserMappingProfile));       
            services.AddAutoMapper(typeof(RoleMappingProfile));
            services.AddAutoMapper(typeof(RoleMappingProfile));
            return services;
        }
    }
}
