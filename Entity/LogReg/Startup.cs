using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LogReg.Models;

namespace LogReg
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
            services.AddDbContext<MainContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));
            services.AddSession();
            services.AddMvc();
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
