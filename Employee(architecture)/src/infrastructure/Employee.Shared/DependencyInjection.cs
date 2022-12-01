using EmployeeAPI.Projects.ProjectService;
using EmployeeAPI.Repositories.Addresses;
using EmployeeAPI.Repositories.Auftrags;
using EmployeeAPI.Repositories.Clients;
using EmployeeAPI.Repositories.Developers;
using EmployeeAPI.Services;
using EmployeeAPI.Services.TarifService;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeAPI.Shared;
public static class DependencyInjection
{
    public static void ConfigureRepository(this IServiceCollection services)
    {
        //services.AddTransient<DeveloperService>();
        //services.AddTransient<AuftragService>();
        //services.AddTransient<AdditionalRepository>();
        services.AddTransient<DeveloperToAuftragRepository>();
        services.AddScoped<IDeveloperRepository, DeveloperRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ITarifRepository, TarifRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IAuftragRepository, AuftragRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();

    }
}
