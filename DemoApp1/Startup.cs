using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.Use(async (context,next) =>
            //{
            //    await context.Response.WriteAsync("middleware 1: Incoing Request \n");
            //    await next();
            //    await context.Response.WriteAsync("Middleware 1:OutGoing Responses\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("middleware 2: Incoing Request \n");
            //    await next();
            //    await context.Response.WriteAsync("Middleware 2:OutGoing Responses\n");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("middleware 3: Incoing Request \n");
            //    await context.Response.WriteAsync("Middleware 3:OutGoing Responses\n");
            //});

           //  app.UseHttpsRedirection();
           // DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
           // defaultFilesOptions.DefaultFileNames.Clear();
           // defaultFilesOptions.DefaultFileNames.Add("MyCustomPage.html");
           // app.UseDefaultFiles(defaultFilesOptions);
           //app.UseStaticFiles();

            FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("MyCustomPage.html");
            app.UseFileServer(fileServerOptions);
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                 {
                     await context.Response.WriteAsync(Configuration["MyCustomKey"]);
                 });

            });

            //app.UseEndpoints(endpoints =>
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
