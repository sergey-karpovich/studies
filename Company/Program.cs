using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Company.Data;
using Company.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// Подключение к базе данных SQLite
// string databasePath="Company.db";
// builder.Services.AddDbContext<CompanyContext>(options=>
//     options.UseSqlite($"Data Source={databasePath}"));

//Подключение к бд SQLServer
string connection = builder.Configuration.GetConnectionString("DefaultConnection2");
builder.Services.AddDbContext<CompanyContext>(options => options.UseSqlServer(connection));

builder.Services.AddTransient<IDataRepository,DataRepository>();
builder.Services.AddTransient<MigrationsManager>();
// builder.Services.AddTransient<IGenericRepository<WorkTime>,
//     GenericRepository<WorkTime>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
