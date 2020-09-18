using Api.Extensions;
using GMV.Api.Extensions;
using GMV.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GMV.Api
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config) => this.config = config;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAndConfigureNodaTime();
            services.AddAndConfigureMediatR();
            services.AddCorsAllowAllPolicy();
            services.AddAndConfigureSwagger(config);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseRouting();
            app.UseAndConfigureSwagger();
            app.UseAllowAllCorsPolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
