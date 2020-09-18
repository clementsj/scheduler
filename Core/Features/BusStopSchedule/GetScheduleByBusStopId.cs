using GMV.Core.Extensions;
using MediatR;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GMV.Core.Features.Routes
{
    public class GetScheduleByBusStopId
    {
        public class Query : IRequest<BusStopSchedule>
        {
            public int Id { get; set; }
        }

        public class BusStopSchedule
        {
            public int Id { get; set; }

            public IEnumerable<string> Route1 { get; set; }

            public IEnumerable<string> Route2 { get; set; }

            public IEnumerable<string> Route3 { get; set; }
        }

        public class Handler : IRequestHandler<Query, BusStopSchedule>
        {
            public Task<BusStopSchedule> Handle(
                Query request,
                CancellationToken cancellationToken)
            {
                return Task.FromResult(new BusStopSchedule
                {
                    Id = request.Id,

                    Route1 = GetScheduleByBusStopId(busId: request.Id, routeId: 1),

                    Route2 = GetScheduleByBusStopId(busId: request.Id, routeId: 2),

                    Route3 = GetScheduleByBusStopId(busId: request.Id, routeId: 3)
                });
            }

            private IEnumerable<string> GetScheduleByBusStopId(int busId, int routeId)
            {
                var startTime = DateTime.Now;
                var moddedTime = startTime.AddMinutes(-15 - busId);
                var baseTime = moddedTime.NextQuarterOfTheHour();

                if (baseTime + ((busId - 1) * 2) < DateTime.Now.Minute)
                {
                    baseTime = DateTime.Now.NextQuarterOfTheHour();
                }

                var baseNumber = (busId + routeId - 2) * 2 + baseTime;
                var scheduledStopTime = startTime.CreateBusStopDateTime(baseNumber);

                return new string[] {
                    scheduledStopTime.ToString("h:mm tt"),
                    scheduledStopTime.AddMinutes(15).ToString("h:mm tt")
                };
            }
        }        
    }
}
