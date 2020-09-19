using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GMV.Api.Controllers;
using GMV.Core.Features.Routes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Test.Extensions;

namespace Test.Controllers
{
    public class RoutesControllerTests
    {
        [TestFixture]
        public class TheGetRouteMethod : TestBase
        {
            protected override void ConfigureServices(IServiceCollection services)
            {
                services.AddScoped<BusStopScheduleController>();
                services.AddMockOf<IMediator>();
            }

            [Test]
            public async Task ShouldReturnTheResultOfMediatorSend()
            {
                var expectedBusStopQuery = new GetScheduleByBusStopId.Query()
                {
                    Id = 1
                };
                var expectedSchedule = new GetScheduleByBusStopId.BusStopSchedule()
                {
                    Id = 1,
                    Route1 = null,
                    Route2 = null,
                    Route3 = null
                };

                // Arrange
                GetMockOf<IMediator>()
                    .Setup(m =>
                        m.Send(
                            It.Is<GetScheduleByBusStopId.Query>(q => q.Id == expectedBusStopQuery.Id),
                            It.IsAny<CancellationToken>()))
                        .ReturnsAsync(expectedSchedule);

                // Act
                var actionResult = await Get<BusStopScheduleController>().GetScheduleByBusStopId(expectedBusStopQuery);

                // Assert
                actionResult.Should().Be(expectedSchedule);
            }
        }
    }
}
