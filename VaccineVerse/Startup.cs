using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineVerse.Business;
using VaccineVerse.Business.BusinessInterfaces;

namespace VaccineVerse
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
            services.AddDbContext<ApiDbContext>(
             options =>
             {
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
             });
            services.AddIdentity<IdentityUser,IdentityRole>()
                .AddEntityFrameworkStores<ApiDbContext>();

            services.AddScoped<IAuthBusiness,AuthBusiness>();
            services.AddScoped<IAppointmentBusiness, AppointmentBusiness>();
            services.AddScoped<IVaccineBusiness, VaccineBusiness>();
            services.AddScoped<IVaccinationCenterBusiness, VaccinationCenterBusiness>();
            services.AddScoped<ILocalAdminBusiness, LocalAdminBusiness>();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "VaccineVerse",
                   
                });
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"Default",
                    pattern:"{controller=Auth}/{action=Register}");
            });
        }
    }
}
