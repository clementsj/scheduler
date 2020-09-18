using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GMV.Core.Extensions
{
    public static partial class StartupExtensions
    {
        public static void AddAndConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
