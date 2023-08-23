using Microsoft.Extensions.Configuration;
using RinhaBackend2023Q3.Application;
using RinhaBackend2023Q3.Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace RinhaBackend2023Q3.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.RegisterApplication();
            services.RegisterInfrastructure(configuration);

            return services;
        }
    }
}