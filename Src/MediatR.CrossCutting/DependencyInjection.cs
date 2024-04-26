using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatR.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var handlers = AppDomain.CurrentDomain.Load("MediatR.Application");
        services.AddMediatR(x => x.RegisterServicesFromAssemblies(handlers));

        return services;

        //adicionar IoF
    }
}
