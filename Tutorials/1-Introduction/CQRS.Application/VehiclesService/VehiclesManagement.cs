using AutoMapper;
using CQRS.Application.VehiclesService.Dtos;
using CQRS.Domain.CQRS.Vehicles.Commands;
using CQRS.Domain.CQRS.Vehicles.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Application.VehiclesService
{
    public class VehiclesManagement : IVehiclesService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VehiclesManagement(
                IMediator mediator,
                IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IEnumerable<VehiclesDto>> GetAllVehicles()
        {
            var vehicles = await _mediator.Send(new GetAllVehiclesQuery());
            var result = _mapper.Map<IEnumerable<VehiclesDto>>(vehicles);
            return result;
        }

        public async Task<IEnumerable<VehiclesDto>> InsertVehicle(CreateVehicleDto input)
        {
            var isCreated = await _mediator.Send(
                    new CreateVehicleCommand(
                        input.Brand, input.Model, input.CategoryDto.Id
                    )
            );
            if (isCreated)
            {
                var result = await GetAllVehicles();
                return result;
            }
            return null;
        }
    }


}
