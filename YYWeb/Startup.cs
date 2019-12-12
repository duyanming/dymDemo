using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Anno.Rpc.Client;

namespace YYWeb
{
    public class Startup
    {
        private CenterInfo config = new CenterInfo();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configuration.GetSection("CenterInfo").Bind(config);
            DefaultConfigManager
                .SetDefaultConfiguration(config.AppName
                , config.IpAddress
                , config.Port
                , config.TraceOnOff);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }


    public class CenterInfo
    {
        public string AppName { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public bool TraceOnOff { get; set; }
    }

}
