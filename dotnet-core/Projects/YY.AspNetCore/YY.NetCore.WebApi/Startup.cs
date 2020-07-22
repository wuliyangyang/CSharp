using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using YY.EF.Core.Interface;
using YY.EF.Core.Service;
using YY.EF.Core.Model;
using Microsoft.EntityFrameworkCore;
using YY.NetCore.WebApi.Consul;

namespace YY.NetCore.WebApi
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

            services.AddSwaggerGen(c => c.SwaggerDoc("v001", new Swashbuckle.AspNetCore.Swagger.Info
            {
                Title = "WeatherForecast",
                Version = "V1"
            }));

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<DbContext, MMContext>();
            services.AddDbContext<MMContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MMDbConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("swagger/v001/swagger.json", "images");
            //});

            app.UseAuthorization();

            loggerFactory.AddLog4Net();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        //实例启动时执行，且只执行一次
            this.Configuration.ConsulRegist();
        }
    }
}
