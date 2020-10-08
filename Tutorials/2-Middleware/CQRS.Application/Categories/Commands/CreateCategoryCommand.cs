using AutoMapper;
using CQRS.Application.Interfaces;
using CQRS.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Categories.Commands
{
    public class CreateCategoryCommand:IRequest<int>
    {
        public string Name { get; set; }
    }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCategoryCommandHandler> _logger;
        public CreateCategoryCommandHandler(
                IContext context,
                IMapper mapper,
                ILogger<CreateCategoryCommandHandler> logger
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
       
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Category>(request);
            var newCategory = await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Created Category:{newCategory.Entity.Id}");
            return newCategory.Entity.Id;
        }
    }

    public class CreateCategoryCommandValidation : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
