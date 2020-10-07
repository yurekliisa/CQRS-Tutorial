using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.Vehicles.QueryHandler.Dto
{
    public class GetAllVehicles
    {
        public IList<VehiclesDto> Vehicles { get; set; }
    }
}
