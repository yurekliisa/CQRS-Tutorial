using System.Collections.Generic;

namespace CQRS.Application.Vehicles.Dto
{
    public class GetAllVehicles
    {
        public IList<VehiclesDto> Vehicles { get; set; }
    }
}
