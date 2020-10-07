using CQRS.Application.Vehicles.QueryHandler.Dto;
using CQRS.Application.Vehicles.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQRS.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Application.Vehicles.QueryHandler
{
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
