using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.VehiclesService.Dtos
{
    public class VehiclesDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
