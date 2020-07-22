using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using YY.EF.Core.Model;
using YY.EF.Core.Service;
using YY.EF.Core.Interface;
using YY.AspNetCore.WebDemo.Utility.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace YY.AspNetCore.WebDemo
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
            services.AddSession();
            services.AddResponseCaching();

            services.AddSwaggerGen(c => c.SwaggerDoc("V001", new Info
            {
                Title = "Images",
                Version = "V1"
            })
            ) ; 

            services.AddControllersWithViews(
                options => {
                    options.Filters.Add<CustomAuthorizeActionFilterAttribute>();  //����ActionFilter��Ȩ����֤
                    //options.Filters.Add<CustomGlobalActionFilterAttribute>();
                    //options.Filters.Add<CustomResourceFilterAttribute>();
                    //options.Filters.Add<CustomActionCacheFilterAttribute>();
                    options.Filters.Add<CustomExceptionFilterAttribute>();//ȫ��ע��Filter
                    
                });

            //ϵͳ�Դ���� ����cookie ��¼ ��Ȩ
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            //{
            //    options.LoginPath = new PathString("/Login/Login");//��Ȩ ��¼�ж�
            //    options.AccessDeniedPath = new PathString("/Home/Pricavy");  //��Ȩ 
            //});
            //services.AddAuthorization();

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<DbContext, MMContext>();  //��DbContextע���MMContext

            services.AddDbContext<MMContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("MMDbConnection"));//ָ�����ݿ�����
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {


            #region �м��
            //app.Use(next =>
            //{
            //    return new RequestDelegate(
            //    async context =>
            //    {
            //        await context.Response.WriteAsync("wait 1 start");
            //        await next.Invoke(context);
            //        await context.Response.WriteAsync("wait 1 end");
            //    });
            //});

            //app.Use(next =>
            //{
            //    return new RequestDelegate(
            //    async context =>
            //    {
            //        await context.Response.WriteAsync("wait 2 start");
            //        //await next.Invoke(context);���һ���м�� ������ next.Invoke(context) 
            //        await context.Response.WriteAsync("wait 2 end");
            //    });
            //});
#endregion

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

            //��Ҫ��ӵ��ļ�·��
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))
            });

            loggerFactory.AddLog4Net();//��Ҫ�����ļ�


            app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/V001/swagger.json", "Images");
            //});

            app.UseResponseCaching();//����������

            app.UseAuthentication();//��Ȩ�������û�е�¼����¼����˭����ֵ��User
            app.UseAuthorization();//������Ȩ�����Ȩ��

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
