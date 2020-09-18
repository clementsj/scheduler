using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMV.Api.Extensions
{
    public static partial class StartupExtensions
    { 
        public static void AddAndConfigureSwagger(
        this IServiceCollection services,
        IConfiguration config)
        {
            services.AddSwaggerGen(s =>
           {
               s.CustomSchemaIds(schemaId => schemaId.FullName);
               s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "GMV Api", Version = "v1" });
           });
        }
  
        public static void UseAndConfigureSwagger( this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(ui =>
           {
               ui.SwaggerEndpoint("v1/swagger.json", "GMV Api v1");
           });
        }
    }
}
