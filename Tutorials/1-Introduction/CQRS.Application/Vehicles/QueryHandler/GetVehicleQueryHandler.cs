using AutoMapper;
using CQRS.Application.Interfaces;
using CQRS.Application.Vehicles.Queries;
using CQRS.Application.Vehicles.QueryHandler.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Vehicles.QueryHandler
{
    public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQuery, VehicleDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IContext _context;
        public GetVehicleQueryHandler(
                IMapper mapper,
                IContext context
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<VehicleDetailDto> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _context.Vehicles.Include(y=>y.Category).FirstOrDefaultAsync(x => x.Id == request.Id);
            VehicleDetailDto result = _mapper.Map<VehicleDetailDto>(vehicle);
            return result;
        }
    }
}
