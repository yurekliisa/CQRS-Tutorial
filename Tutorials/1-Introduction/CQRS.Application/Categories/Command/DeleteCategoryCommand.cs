using CQRS.Application.Interfaces;
using CQRS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Categories.Command
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IContext _context;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;

        public DeleteCategoryCommandHandler(
                IContext context,
                ILogger<DeleteCategoryCommandHandler> logger
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.FindAsync(request.Id);
            if (entity == null)
            {
                new Exception($"Entity \"{nameof(Category)}\" ({request.Id}) was not found.");
            }
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Deleted Category:{entity.Id}");
            return Unit.Value;
        }
    }
}
