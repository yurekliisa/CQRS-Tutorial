using AutoMapper;
using CQRS.Application.Interfaces;
using CQRS.Application.Vehicles.Commands;
using CQRS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Vehicles.CommandHandlers
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateVehicleCommandHandler> _logger;

        public UpdateVehicleCommandHandler(
                IContext context,
                IMapper mapper,
                                ILogger<UpdateVehicleCommandHandler> logger

            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vehicles.FindAsync(request.Id);
            if (entity == null)
            {
                new Exception($"Entity \"{nameof(Vehicle)}\" ({request.Id}) was not found.");
            }
            entity.Brand = request.Brand;
            entity.CategoryId = request.CategoryId;
            entity.Model = request.Model;
            entity.Year = request.Year;
            
            //= _mapper.Map<Vehicle>(request);
            _context.Vehicles.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Updated Vehicle:{entity.Id}");

            return Unit.Value;
        }
    }
}
