using CQRS.Application.VehiclesService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.VehiclesService
{
    public interface IVehiclesService
    {
        Task<IEnumerable<VehiclesDto>> GetAllVehicles();
        Task<IEnumerable<VehiclesDto>> InsertVehicle(CreateVehicleDto create);
    }
}
