using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Settings;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Services;
using EmployeeAPI.Application;
using EmployeeAPI.Contexts;
using EmployeeAPI.Application.Common.Logging;
using EmployeeAPI.Application.Common.Exceptions;
using EmployeeAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configure authentification
//builder.Services.ConfigureIdentity(builder.Configuration);
//builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddIdentityCore<ApiUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<ApiUser>>(builder.Configuration["Jwt:Issuer"])
    .AddEntityFrameworkStores<CompanyContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // "Bearer"
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
        .GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddResponseCaching(options =>
{
    options.MaximumBodySize = 1024;
    options.UseCaseSensitivePaths = true;
});

// Logger
LogConfiguration.ConfigurateLogger(builder);

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddControllers().AddNewtonsoftJson();

//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
//    options.JsonSerializerOptions.WriteIndented = true;
//});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddApplication(builder.Configuration);

// Configure dbContext
string connection = builder.Configuration.GetConnectionString("EmployeeAPICon");
builder.Services.AddDbContext<CompanyContext>(options =>
    options.UseSqlServer(connection));
// Configure repository
EmployeeAPI.Shared.DependencyInjection.ConfigureRepository(builder.Services);



builder.Services.AddScoped<IAuthManager, AuthManager>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<CustomExceptionMiddleware>();
 
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseResponseCaching();

app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl =
        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
        {
            Public = true,
            MaxAge = TimeSpan.FromSeconds(10)
        };
    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
        new string[] { "Accept-Encoding" };

    await next();
});

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

AppDbInitialize.Seed(app);

app.Run();
