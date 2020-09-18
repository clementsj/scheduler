using Microsoft.Extensions.DependencyInjection;
using NodaTime;

namespace GMV.Core.Extensions
{
    public partial class StartupExtensions
    {
        public static void AddAndConfigureNodaTime(this IServiceCollection services)
        {
            services.AddSingleton<IClock>(SystemClock.Instance);
        }
    }
}
