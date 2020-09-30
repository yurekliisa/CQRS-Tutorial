using CQRS.Application.CategoryService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.VehiclesService.Dtos
{
    public class CreateVehicleDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
