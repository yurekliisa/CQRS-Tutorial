using AutoMapper;
using CQRS.Application.Categories.Dto;
using CQRS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Categories.Query
{
    public class GetCategoryQuery : IRequest<CategoryDetailDto>
    {
        public int Id { get; set; }
    }
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IContext _context;
        public GetCategoryQueryHandler(
                IMapper mapper,
                IContext context
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CategoryDetailDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            CategoryDetailDto result = _mapper.Map<CategoryDetailDto>(category);
            return result;
        }
    }

}
