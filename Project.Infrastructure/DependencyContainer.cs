using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Contracts.Persistence;
using Project.Infrastructure.Persistence.Repositories;
using System.Data.SQLite;

namespace Project.Infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection RegisterInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddSingleton(new SQLiteConnection()
        {
            ConnectionString = configuration.GetConnectionString("ProjectDbConnectionString")
        });

        _ = services.AddScoped<IWalletRepository, WalletRepository>();

        return services;
    }
}