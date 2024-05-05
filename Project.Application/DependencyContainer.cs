using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Project.Application;

public static class DependencyContainer
{
    public static IServiceCollection RegisterApplicationDependency(this  IServiceCollection services)
    {
        services.AddMediatR(mediatR =>
        {
            mediatR.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}