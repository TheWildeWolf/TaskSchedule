using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Data;
using Data;
using Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Interfaces;
using WebApp.Services;

namespace WebApp
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
            services.AddScoped<IAppoinmentRepo, AppoinmentRepo>();
            services.AddScoped<IPassengerRepo, PassengerRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWorkRepo>();
            services.AddScoped<IScheduleRepo, ScheduleRepo>();

            services.AddScoped<IPassengerViewModelService, PassengerViewModelService>();
            services.AddScoped<IAppoinmentViewModelService, AppoinmentViewModelServices>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            ConfigureMySQL(services);
        }

        void ConfigureMySQL(IServiceCollection services)
        {
            services.AddDbContext<SchedulerDbContext>(opt => opt.UseMySQL("Server=localhost;Port=3306;Database=ScheduleDb;Uid=root;Pwd=123456;",b=>b.MigrationsAssembly("Data")));
        }

        void ConfiqureTestInMemory(IServiceCollection services)
        {
            services.AddDbContext<SchedulerDbContext>(opt => opt.UseInMemoryDatabase("ScheduleDb"));

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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
