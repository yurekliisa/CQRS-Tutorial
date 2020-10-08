using CQRS.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQRS.Domain.Entities
{
    public class Vehicle:EntityBase<int>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
