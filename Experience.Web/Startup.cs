﻿using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Experience.Web {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app) {
            app.UseIISPlatformHandler();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Default}/{action=Index}/");
            });
            app.UseStaticFiles();
        }
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}