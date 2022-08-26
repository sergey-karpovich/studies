using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.IO;

using Microsoft.AspNetCore.Routing;
using static System.Console;
using Microsoft.Extensions.FileProviders;

namespace NorthwindWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseHsts();
            }

            app.UseRouting();

            app.Use(async(HttpContext context,Func<Task>next)=>
            {
                var rep = context.GetEndpoint()as RouteEndpoint;
                if(rep!=null)
                {
                    WriteLine($"Endpoint name: {rep.DisplayName}");
                    WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
                }
                if(context.Request.Path=="/bonjour")
                {
                    // в случае совпадения URL-пути это становится завершающим делегатом, 
                    // который возвращается, поэтому вызов следующего делегата не происходит    
                    await context.Response.WriteAsync("Bonjour Monde!");   
                    return; 
                }
                 // мы могли изменить запрос перед вызовом следующего делегата  
                 await next();  
                 // мы могли изменить ответ после вызова следующего делегата 
            });

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapGet("/hello", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
