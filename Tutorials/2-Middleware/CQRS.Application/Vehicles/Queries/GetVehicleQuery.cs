using AutoMapper;
using CQRS.Application.Interfaces;
using CQRS.Application.Vehicles.Dto;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Vehicles.Queries
{
    public class GetVehicleQuery : IRequest<VehicleDetailDto>
    {
        public int Id { get; set; }
    }

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
            var vehicle = await _context.Vehicles.Include(y => y.Category).FirstOrDefaultAsync(x => x.Id == request.Id);
            VehicleDetailDto result = _mapper.Map<VehicleDetailDto>(vehicle);
            return result;
        }
    }

    public class GetVehicleQueryValidation : AbstractValidator<GetVehicleQuery>
    {
        public GetVehicleQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
