using DemoMediatR.Application.Behaviors;

using FluentValidation;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoMediatR.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        //services.AddScoped<IPersonRepository, PersonRepository>();
        //services.AddScoped<IPersonDapperRepository, PersonDapperRepository>();

        const string applicationAssemblyName = "DemoMediatR.Application";

        var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

        AssemblyScanner
            .FindValidatorsInAssembly(assembly)
            .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

        services.AddMediatR(configuration =>
        {
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

            configuration.RegisterServicesFromAssemblies(assembly);
        });

        return services;
    }
}
