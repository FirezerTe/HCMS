using HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SMS.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(CreateBusinessUnitCommand).Assembly);
        });

        return services;
    }
}
