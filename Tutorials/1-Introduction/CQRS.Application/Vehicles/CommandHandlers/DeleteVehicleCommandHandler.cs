using CQRS.Application.Interfaces;
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
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand>
    {
        private readonly IContext _context;
        private readonly ILogger<DeleteVehicleCommandHandler> _logger;

        public DeleteVehicleCommandHandler(
                IContext context,
                ILogger<DeleteVehicleCommandHandler> logger
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vehicles.FindAsync(request.Id);
            if (entity == null)
            {
                new Exception($"Entity \"{nameof(Vehicle)}\" ({request.Id}) was not found.");
            }
            _context.Vehicles.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Deleted Vehicle:{entity.Id}");
            return Unit.Value;
        }
    }
}
