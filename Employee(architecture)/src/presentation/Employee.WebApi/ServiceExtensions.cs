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
        //public static void ConfigureIdentity(this IServiceCollection services,
        //    IConfiguration configuration)
        //{
        //    services.AddIdentityCore<ApiUser>()
        //    .AddRoles<IdentityRole>()
        //    .AddTokenProvider<DataProtectorTokenProvider<ApiUser>>(
        //        configuration["Jwt:Issuer"])
        //    .AddEntityFrameworkStores<CompanyContext>()
        //    .AddDefaultTokenProviders();
           
        //    //var builder = services.AddIdentityCore<ApiUser>(q => 
        //    //q.User.RequireUniqueEmail = true);

        //    //var issuer = configuration["Jwt:Issuer"];

        //    //builder = new IdentityBuilder(builder.UserType, 
        //    //    typeof(IdentityRole), services);
        //    //builder.AddTokenProvider(issuer, typeof(DataProtectorTokenProvider<ApiUser>));
        //    //builder.AddEntityFrameworkStores<CompanyContext>()
        //    //    .AddDefaultTokenProviders();

        //}
        //public static void ConfigureJWT(this IServiceCollection services, IConfiguration Configuration)
        //{
        //    services.AddAuthentication(options => {
        //         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // "Bearer"
        //         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //     }).AddJwtBearer(options => {
        //         options.TokenValidationParameters = new TokenValidationParameters
        //         {
        //             ValidateIssuerSigningKey = true,
        //             ValidateIssuer = true,
        //             ValidateAudience = true,
        //             ValidateLifetime = true,
        //             ClockSkew = TimeSpan.Zero,
        //             ValidIssuer = Configuration["Jwt:Issuer"],
        //             ValidAudience = Configuration["Jwt:Audience"],
        //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
        //             .GetBytes(Configuration["Jwt:Key"]))
        //         };
        //     });
            //var jwtSettings = Configuration.GetSection("Jwt");
            //var key = Configuration["Jwt:Key"];
            //// Если записать ключ в системе то можно получить так:
            ////var key = Environment.GetEnvironmentVariable("KEY");

            //services.AddAuthentication(o => {
            //    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(o =>
            //    {
            //        o.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = jwtSettings.GetSection("Issuer").Value,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            //            .GetBytes(key))
            //        };
            //    });
        //}


    }
}
