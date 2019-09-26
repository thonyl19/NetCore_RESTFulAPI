using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCore_RESTFulAPI.Models;

namespace NetCore_RESTFulAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // using(var client = new DBSContext())
            // {
            //     //呼叫 dbContext.Database.EnsureCreated()，
            //     //  當啟動 Website 時就會建立資料庫
            //     client.Database.EnsureCreated();
            // }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            在 ASP.NET Core 中，資料庫內容等服務必須向相依性插入 (DI) 容器註冊。 
                此容器會將服務提供給控制器。
            */
            // services.AddDbContext<TodoContext>(opt =>
            //     opt.UseInMemoryDatabase("TodoList"));

            /*
            
             */
            services
                .AddDbContext<DBSContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("Sqlite"))
                );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routes=>{
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                    
                routes.MapRoute(
                    name: "API",
                    template: "api/{action=Index}/{id?}"
                );
            });

 
        }
    }
}
