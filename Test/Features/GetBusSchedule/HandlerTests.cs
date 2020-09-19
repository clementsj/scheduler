
using FluentAssertions;
using GMV.Core.Features.Routes;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Test.Extensions;
using static GMV.Core.Features.Routes.GetScheduleByBusStopId;

namespace Test.Features.GetBusSchedule
{
    public class HandlerTests
    {
        [TestFixture]
        public class TheHandleMethod : TestBase
        {
            protected override void ConfigureServices(IServiceCollection services)
            {
                services.AddScoped<Handler>();
                services.AddMockOf<IDateTimeHelper>();
            }



            [Test]
            public async Task ShouldReturnRoutesByBusId()
            {
                GetMockOf<IDateTimeHelper>()
                    .Setup(m =>
                        m.GetDateTimeNow())
                        .Returns(new DateTime(2020, 9, 18, 18, 32, 0));

                var page = await Get<Handler>()
                    .Handle(
                    new Query { Id = 1 }, CancellationToken.None);

                page.Id.Should().Be(1);
                page.Route1.Should().HaveCount(2);
                page.Route2.Should().HaveCount(2);
                page.Route3.Should().HaveCount(2);
            }

            [Test]
            public  async Task ShouldReturnScheduleForBusStopOne ()
            {
                GetMockOf<IDateTimeHelper>()
                    .Setup(m =>
                        m.GetDateTimeNow())
                        .Returns(new DateTime(2020, 9, 18, 18, 32, 0));

                var expectedSchedule = new GetScheduleByBusStopId.BusStopSchedule()
                {
                    Id = 1,
                    Route1 = new List<string>{ "6:45 PM", "7:00 PM" },
                    Route2 = new List<string> { "6:47 PM", "7:02 PM" },
                    Route3 = new List<string> { "6:49 PM", "7:04 PM" }
                };

                var page = await Get<Handler>()
                    .Handle(
                    new Query { Id = 1 }, CancellationToken.None);

                page.Id.Should().Be(expectedSchedule.Id);
                page.Route1.Should()
                    .Contain(expectedSchedule.Route1); 
            }
        }
    }
}
