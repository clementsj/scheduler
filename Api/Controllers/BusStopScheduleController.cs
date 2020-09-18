using GMV.Core.Features.Routes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GMV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusStopScheduleController
    {
        private readonly IMediator mediator;

        public BusStopScheduleController(IMediator mediator) => this.mediator = mediator;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(GetScheduleByBusStopId.BusStopSchedule), StatusCodes.Status200OK)]
        public async Task<GetScheduleByBusStopId.BusStopSchedule> GetScheduleByBusStopId(
            [FromQuery] GetScheduleByBusStopId.Query query) =>
            await mediator.Send(query);
    }
}