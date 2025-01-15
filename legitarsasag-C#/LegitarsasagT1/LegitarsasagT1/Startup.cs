using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LegitarsasagT1.Repository.FlightDbContext;
using LegitarsasagT1.Service;
using LegitarsasagT1.Service.Impl;

namespace LegitarsasagT1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<FlightDbContext>(opt => opt.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddTransient<FlightDbContext>();
            services.AddTransient<IAirlineService, AirlineServiceImpl>();
            services.AddTransient<ICityService, CityServiceImpl>();
            services.AddTransient<IFlightService, FlightServiceImpl>();
            services.AddTransient<IUploadService, UploadServiceImpl>();
            services.AddTransient<IResultService, ResultServiceImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
