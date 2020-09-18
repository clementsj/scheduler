using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public static partial class StartupExtensions
    {
        public static void AddCorsAllowAllPolicy(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
           {
               builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
           }));
        }

        public static void UseAllowAllCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors("AllowAll");
        }
    }
}
