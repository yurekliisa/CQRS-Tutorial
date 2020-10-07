using AutoMapper;
using CQRS.Application.Interfaces;
using CQRS.Application.Vehicles.CommandHandlers.Dto;
using CQRS.Application.Vehicles.Commands;
using CQRS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Vehicles.CommandHandlers
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, CreatedVehicle>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateVehicleCommandHandler> _logger;
        public CreateVehicleCommandHandler(
                IContext context,
                IMapper mapper,
                ILogger<CreateVehicleCommandHandler> logger
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<CreatedVehicle> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Vehicle>(request);
            var newVehicle = await _context.Vehicles.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Created Vehicle:{newVehicle.Entity.Id}");
            return new CreatedVehicle(newVehicle.Entity.Id);
        }
    }
}
