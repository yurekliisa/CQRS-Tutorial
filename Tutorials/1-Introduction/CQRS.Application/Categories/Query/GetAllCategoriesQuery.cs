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
    public class GetAllCategoriesQuery : IRequest<GetAllCategories>
    {
    }

    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, GetAllCategories>
    {
        private readonly IMapper _mapper;
        private readonly IContext _context;
        public GetAllCategoriesQueryHandler(
                IMapper mapper,
                IContext context
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
   
        public async Task<GetAllCategories> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.ToListAsync();
            return new GetAllCategories()
            {
                Categories = _mapper.Map<List<CategoryDetailDto>>(categories)
            };
        }
    }
}
