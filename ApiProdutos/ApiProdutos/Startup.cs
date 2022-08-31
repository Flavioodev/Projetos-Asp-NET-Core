using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutos
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
            services.AddControllers();
            services.AddRazorPages();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiProdutos", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder appBuild, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                appBuild.UseDeveloperExceptionPage();
                
            }
            else
            {
                appBuild.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.


                appBuild.UseHsts();
            }

            appBuild.UseHttpsRedirection();
            appBuild.UseStaticFiles();

            appBuild.UseRouting();

            appBuild.UseAuthorization();

            appBuild.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            appBuild.UseSwagger();
            appBuild.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiProdutos v1");
            });

        }
    }
}
