using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;


namespace Test
{
    public abstract class TestBase
    {
        private ServiceProvider serviceProvider;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            serviceProvider = services.BuildServiceProvider();
        }

        protected virtual void ConfigureServices(IServiceCollection services) { }

        protected T Get<T>() => serviceProvider.GetService<T>();

        protected Mock<T> GetMockOf<T>() where T : class => serviceProvider.GetService<Mock<T>>();
    }
}
