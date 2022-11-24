using EmployeeAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeAPI.Shared;
public static class DependencyInjection
{
    public static void ConfigureRepository(this IServiceCollection services)
    {
        //services.AddTransient<DeveloperService>();
        services.AddTransient<AdditionalRepository>();
        //services.AddTransient<AuftragService>();
        services.AddTransient<DeveloperToAuftragRepository>();
        
    }
}
