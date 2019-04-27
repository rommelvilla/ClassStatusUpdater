using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassStatusUploader.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassStatusUploader
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .WithMethods("GET", "POST")
                    .AllowAnyHeader()
                    .WithOrigins(Configuration.GetValue<string>("uiUrl"))
                    .AllowCredentials();
            }));
            services.AddSignalR();
            services.AddHostedService<ServiceBusListener>();
            services.AddMvc();
            services.Configure<ServiceBusConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseSignalR(routes =>
            {
                routes.MapHub<TeamHub>("/teamHub");
            });
            app.UseMvcWithDefaultRoute();
            
        }
    }
}
