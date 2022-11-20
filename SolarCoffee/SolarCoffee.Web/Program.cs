using Microsoft.EntityFrameworkCore;
using SolarCoffee.Data;
using SolarCoffee.Services.CustomerService;
using SolarCoffee.Services.InventoryService;
using SolarCoffee.Services.OrderService;
using SolarCoffee.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SolarDbContext>(options =>
{
    options.EnableDetailedErrors();
    options.UseSqlServer(connection);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IInventoryService, InventoryService>();
builder.Services.AddTransient<IOrderService, OrderService>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(c =>
{
    c.AddPolicy(name: MyAllowSpecificOrigins, options =>
        options
        .WithOrigins(
            "http://localhost:8080",
            "http://localhost:8081",
            "http://localhost:8082")
        //.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
