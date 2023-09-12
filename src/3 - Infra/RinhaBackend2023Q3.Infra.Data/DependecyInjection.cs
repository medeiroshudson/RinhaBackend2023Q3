using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RinhaBackend2023Q3.Domain.Interfaces.Infra.Context;
using RinhaBackend2023Q3.Infra.Data.Context;

namespace RinhaBackend2023Q3.Infra.Data;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseNpgsql(
                connectionString,
                builder =>
                    builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            );
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
