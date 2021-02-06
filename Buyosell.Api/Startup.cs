using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buyosell.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Buyosell.Data;
using Buyosell.Core.IService;
using Buyosell.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Buyosell.Api
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
            services.AddDbContext<BuyosellContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Default"),
                                 x => x.MigrationsAssembly("Buyosell.Data")).UseLazyLoadingProxies());

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAdService, AdService>();
            services.AddTransient<IAdWallService, AdWallService>();
            services.AddTransient<IUserFeedService, UserFeedService>();
            services.AddTransient<IAuthService, AuthService>();


            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Buyosell", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Buyosell V1");
            });
        }
    }
}
