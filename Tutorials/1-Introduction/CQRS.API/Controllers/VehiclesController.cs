using System.Threading.Tasks;
using CQRS.Application.Vehicles.Commands;
using CQRS.Application.Vehicles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VehiclesController(
                IMediator mediator
            )
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _mediator.Send(new GetAllVehiclesQuery());
            return Ok(vehicles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleCommand input)
        {
            var isCreated = await _mediator.Send(input);
            return Ok(isCreated);
        }
    }
}
