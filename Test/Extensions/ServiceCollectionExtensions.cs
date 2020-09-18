using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Test.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMockOf<T>(this IServiceCollection services)
            where T : class
        {
            var mock = new Mock<T>();
            services.AddSingleton<Mock<T>>(mock);
            services.AddSingleton<T>(mock.Object);
        }
    }
}
