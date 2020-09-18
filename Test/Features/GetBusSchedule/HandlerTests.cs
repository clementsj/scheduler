
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using static GMV.Core.Features.Routes.GetScheduleByBusStopId;

namespace Test.Features.GetBusSchedule
{
    public class HandlerTests
    {
        public class TheHandleMethod : TestBase
        {
            protected override void ConfigureServices(IServiceCollection services)
            {
                services.AddScoped<Handler>();
            }

            [Test]
            public async Task ShouldReturnRoutesByBusId()
            {
                var page = await Get<Handler>()
                    .Handle(
                    new Query { Id = 1 }, CancellationToken.None);

                page.Id.Should().Be(1);
                page.Route1.Should().HaveCount(2);
                page.Route2.Should().HaveCount(2);
                page.Route3.Should().HaveCount(2);
            }
        }
    }
}
