using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Application.VehiclesService;
using CQRS.Application.VehiclesService.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CQRS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesService _vehiclesService;

        public VehiclesController(
            IVehiclesService vehiclesService
            )
        {
            _vehiclesService = vehiclesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var result = await _vehiclesService.GetAllVehicles();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleDto input)
        {
            var result = await _vehiclesService.InsertVehicle(input);
            return Ok(result);
        }
    }
}
