using AutoMapper;
using CQRS.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Categories.Command
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(
                IContext context,
                IMapper mapper,
                ILogger<UpdateCategoryCommandHandler> logger
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.FindAsync(request.Id);
            if (entity == null)
            {
                new Exception($"Entity \"{nameof(Categories)}\" ({request.Id}) was not found.");
            }
            entity.Name = request.Name;
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Updated Category:{entity.Id}");
            return Unit.Value;
        }
    }
}
