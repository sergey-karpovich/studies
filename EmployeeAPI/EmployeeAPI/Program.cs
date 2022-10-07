using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models.Repository;
using EmployeeAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(c =>
{
    c.AddPolicy(name: MyAllowSpecificOrigins, options =>
        options
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling
    .Ignore).AddNewtonsoftJson(options =>
    options.SerializerSettings.ContractResolver =
    new DefaultContractResolver());

builder.Services.AddControllers();

string connection = builder.Configuration.GetConnectionString("EmployeeAPICon");
builder.Services.AddDbContext<CompanyContext>(options => options.UseSqlServer(connection));

builder.Services.AddTransient<IDataRepository, DataRepository>();

//builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
    RequestPath = "/Photos"
});

app.UseCors(MyAllowSpecificOrigins);

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
