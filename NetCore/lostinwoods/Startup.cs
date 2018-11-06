using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using lostinwoods.Factory;

namespace lostinwoods
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
            services.Configure<MySqlOptions>(Configuration.GetSection("DBInfo"));
            services.AddScoped<MainFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
