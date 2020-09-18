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

            public IEnumerable<int> Route1 { get; set; }

            public IEnumerable<int> Route2 { get; set; }

            public IEnumerable<int> Route3 { get; set; }
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

            private IEnumerable<int> GetScheduleByBusStopId(int busId, int routeId)
            {
                var baseTime = DateTime.Now.AddMinutes(-15).NextQuarterOfTheHour();
                var baseNumber = (busId + routeId - 2) * 2 + baseTime;

                if (baseNumber < DateTime.Now.Minute)
                {
                    baseTime = DateTime.Now.NextQuarterOfTheHour();
                    baseNumber = (busId + routeId - 2) * 2 + baseTime;
                }

                return new int[] { baseNumber % 60, (baseNumber + 15) % 60 };
            }
        }        
    }
}
