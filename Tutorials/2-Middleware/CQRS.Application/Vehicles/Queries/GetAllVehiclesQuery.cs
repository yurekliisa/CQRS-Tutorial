using AutoMapper;
using CQRS.Application.Interfaces;
using CQRS.Application.Vehicles.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Vehicles.Queries
{
    public class GetAllVehiclesQuery:IRequest<GetAllVehicles>
    {
    }
    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, GetAllVehicles>
    {
        private readonly IMapper _mapper;
        private readonly IContext _context;
        public GetAllVehiclesQueryHandler(
                IMapper mapper,
                IContext context
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetAllVehicles> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return new GetAllVehicles()
            {
                Vehicles = _mapper.Map<List<VehiclesDto>>(vehicles)
            };
        }
    }
}
