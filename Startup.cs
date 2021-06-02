using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data;
using FoodDelivery.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace FoodDelivery1
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
			services.AddDbContext<Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UserConnection")));
			services.AddCors();
            services.AddControllers().AddNewtonsoftJson(s => { s.SerializerSettings.ContractResolver = new 
					CamelCasePropertyNamesContractResolver();});
			services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));


			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IOrderService,OrderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();

			app.UseCors(x => x
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());

			app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
