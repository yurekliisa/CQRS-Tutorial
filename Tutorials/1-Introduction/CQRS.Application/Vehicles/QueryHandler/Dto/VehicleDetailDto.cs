using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.Vehicles.QueryHandler.Dto
{
    public class VehicleDetailDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
