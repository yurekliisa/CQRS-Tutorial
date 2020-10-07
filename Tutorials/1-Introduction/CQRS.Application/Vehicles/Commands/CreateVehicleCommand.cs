using CQRS.Application.Vehicles.CommandHandlers.Dto;
using MediatR;

namespace CQRS.Application.Vehicles.Commands
{
    public class CreateVehicleCommand:IRequest<CreatedVehicle>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int CategoryId { get; set; }
    }
}
