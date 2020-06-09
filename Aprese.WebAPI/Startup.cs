using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aprese.Repository;
using Aprese.Repository.DefaultImpl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Aprese.WebAPI
{
    public class Startup
    {
        public const string CONN_STRING = "Default";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApreseContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString(CONN_STRING), o =>
                {
                    o.ServerVersion(new Version(8, 0, 0), ServerType.MySql);
                });
            });
            services.AddEventsAndRules();

            services.AddTransient<TestCommit>();
        }

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
        }
    }
}
