using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(
    new StaticFileOptions
                {
                    FileProvider=new PhysicalFileProvider(
                        Path.Combine(builder.Environment.ContentRootPath,
                        "MyStaticFiles")),
                        RequestPath="/StaticFiles"
                }
);
app.UseRouting();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
