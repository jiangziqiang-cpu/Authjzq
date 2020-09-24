using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetStudy.Web.MappingProfiles
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMappingProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserMappingProfile));
            services.AddAutoMapper(typeof(PurseMappingProfile));
            services.AddAutoMapper(typeof(MyAddressMappingProfile));
            services.AddAutoMapper(typeof(OrderMappingProfile));
            services.AddAutoMapper(typeof(OrderDetailsMappingProfile));            
            return services;
        }
    }
}
