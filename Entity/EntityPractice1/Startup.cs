using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using EntityPractice1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityPractice1
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public Startup(IHostingEnvironment env)
        {
            Console.WriteLine(env.ContentRootPath);
            Console.WriteLine(env.IsDevelopment());
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", true, true).AddEnvironmentVariables();
            Configuration = builder.Build();
        } 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddMvc();
            services.AddDbContext<MainContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
