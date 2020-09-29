using CQRS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Domain.Entities
{
    public class Category : EntityBase<int>
    {
        public string Name { get; set; }

        public int ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
