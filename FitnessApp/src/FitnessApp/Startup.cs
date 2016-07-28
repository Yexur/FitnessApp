﻿using FitnessApp.IRepository;
using FitnessApp.Logic;
using FitnessApp.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FitnessApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            var connection = @"Server=localhost\SQLEXPRESS;Database=FITNESS_APP;Integrated Security=True;MultipleActiveResultSets=True;";
            services.AddDbContext<FitnessAppContext>(options => options.UseSqlServer(connection));

            //Add application services
            //Repo Services  
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<IRegistrationRecordRepository, RegistrationRecordRepository>();
            services.AddTransient<IFitnessClassRepository, FitnessClassRepository>();
            services.AddTransient<IFitnessClassTypeRepository, FitnessClassTypeRepository>();

            //Logic services
            services.AddTransient<ILocationLogic, LocationLogic>();
            services.AddTransient<IInstructorLogic, InstructorLogic>();
            services.AddTransient<IRegistrationRecordLogic, RegistrationRecordLogic>();
            services.AddTransient<IFitnessClassLogic, FitnessClassLogic>();
            services.AddTransient<IFitnessClassTypeLogic, FitnessClassTypeLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
