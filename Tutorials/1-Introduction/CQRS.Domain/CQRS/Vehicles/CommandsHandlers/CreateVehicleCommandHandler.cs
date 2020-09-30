using CQRS.Core.Repository;
using CQRS.Domain.CQRS.Vehicles.Commands;
using CQRS.Domain.CQRS.Vehicles.Queries;
using CQRS.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Domain.CQRS.Vehicles.CommandsHandlers
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, bool>
    {
        private readonly IRepositoryBase<Vehicle, int> _vehicleRepository;

        public CreateVehicleCommandHandler(
                IRepositoryBase<Vehicle, int> vehicleRepository
            )
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<bool> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle()
            {
                Brand = request.Brand,
                CategoryId = request.CategoryId,
                Model = request.Model
            };
            try
            {
                await _vehicleRepository.InsertAsync(vehicle);
                await _vehicleRepository.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
