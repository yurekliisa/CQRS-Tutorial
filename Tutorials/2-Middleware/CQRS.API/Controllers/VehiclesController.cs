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

        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetVehicleById(int vehicleId)
        {
            var vehicle = await _mediator.Send(new GetVehicleQuery() { Id = vehicleId });
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleCommand input)
        {
            var isCreated = await _mediator.Send(input);
            return Ok(isCreated);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateVehicle(int id, UpdateVehicleCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{vehicleId}")]
        public async Task<ActionResult> Delete(int vehicleId)
        {
            await _mediator.Send(new DeleteVehicleCommand { Id = vehicleId });
            return NoContent();
        }
    }
}
