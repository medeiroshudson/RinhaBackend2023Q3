using Microsoft.Extensions.DependencyInjection;
using RinhaBackend2023Q3.Application.Services;
using RinhaBackend2023Q3.Domain.Interfaces.Services;

namespace RinhaBackend2023Q3.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddTransient<IPersonService, PersonService>();

        return services;
    }
}
