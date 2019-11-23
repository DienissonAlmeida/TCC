using eFlight.Infra.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace eFlight.API.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.ConfigureProfiles(typeof(API.Startup), typeof(Application.AppModule));
        }
    }
}
