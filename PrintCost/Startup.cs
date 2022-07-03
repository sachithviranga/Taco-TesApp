using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrintCost.Business.FileHandler;
using PrintCost.Business.Manager;
using PrintCost.Business.Validator;
using PrintCost.Common.Mapper;
using PrintCost.Context;
using PrintCost.Contracts.Common;
using PrintCost.Contracts.FileHandler;
using PrintCost.Contracts.Manager;
using PrintCost.Contracts.Repository;
using PrintCost.Data.Mapper;
using PrintCost.Data.Repository;
using PrintCost.Entities;
using PrintCost.Entities.Common;
using System;
using System.Collections.Generic;

namespace PrintCost
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
            // Register DB Context
            services.AddDbContext<PrintCostContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefultConnection")));

            services.AddControllersWithViews();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Register AutoMapper Configuration
            var autoMapperConfig = new MapperConfiguration(o => o.AddProfile(new AutoMapperProfile()));

            IMapper mappper = autoMapperConfig.CreateMapper();

            services.AddSingleton(mappper);

            // Regiter Dependancies
            #region Dependancies

            // Mappers
            services.AddSingleton<IMapper<Message, ServiceResponse>, ServiceErrorMapper>();
            services.AddSingleton<IMapper<Object, ServiceResponse>, ServiceResponseMapper>();

            // Validator
            services.AddScoped<IValidator<CostCalculate>, CalculateCostValidator>();

            // Handler
            services.AddSingleton<IFileReader, FileReader>();

            // Manager
            services.AddScoped<ICalculateCostManager, CalculateCostManager>();
            
            // Repositories
            services.AddScoped<IPriceRepository, PriceRepository>();

            #endregion
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
