using CQRS.Core.Repository;
using CQRS.Domain.CQRS.Vehicles.Queries;
using CQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Domain.CQRS.Vehicles.QueriesHandlers
{
    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, IEnumerable<Vehicle>>
    {
        private readonly IRepositoryBase<Vehicle, int> _vehicleRepository;
        public GetAllVehiclesQueryHandler(
                IRepositoryBase<Vehicle, int> vehicleRepository
            )
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.Run(() =>
            {
                return _vehicleRepository.GetQueryable().AsEnumerable();
            });
            return result;
        }
    }
}
