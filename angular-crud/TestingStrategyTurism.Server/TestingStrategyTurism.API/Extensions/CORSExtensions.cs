using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Turism.Infra;
using Turism.Infra.Settings;

namespace TestingStrategyTurism.API.Extensions
{
    public static class CORSExtensions
    {
        public static void UseCORS(this IApplicationBuilder app, IConfiguration configuration)
        {
            var corsSettings = configuration.LoadSettings<CORSSettings>("CORSSettings") ?? new CORSSettings().Default();

            app.UseCors(builder => builder
                                    .WithOrigins(corsSettings.Origins)
                                    .WithMethods(corsSettings.Methods)
                                    .WithHeaders(corsSettings.Headers)
                                    .Build());
        }
    }
}
