using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Data.Contexts;

namespace EmployeeAPI.Domain.Settings
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUser>(q => 
            q.User.RequireUniqueEmail = true);

            builder = new IdentityBuilder(builder.UserType, 
                typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<CompanyContext>()
                .AddDefaultTokenProviders();

        }
        public static async void ConfigureJWT(this IServiceCollection services, IConfiguration Configuration)
        {
            var jwtSettings = Configuration.GetSection("Jwt");
            var key = Configuration["Jwt:Key"];
            // Если записать ключ в системе то можно получить так:
            //var key = Environment.GetEnvironmentVariable("KEY");

            services.AddAuthentication(o => {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                });
        }


    }
}
