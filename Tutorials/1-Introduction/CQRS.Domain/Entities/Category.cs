using CQRS.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQRS.Domain.Entities
{
    public class Category : EntityBase<int>
    {
        public string Name { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
