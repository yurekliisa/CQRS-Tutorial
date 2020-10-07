using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.Categories.Dto
{
    public class GetAllCategories
    {
        public List<CategoryDetailDto> Categories { get; set; }
    }
}
