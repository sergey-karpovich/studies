using EmployeeAPI.Application.Common.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeAPI.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services, IConfiguration config)
    {        
        services.AddAutoMapper(typeof(MapperConfig));

        return services;
    }
}
