using CQRS.Application.Interfaces;
using CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Infrastructure.Context
{
    public class CQRSContext:DbContext, IContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CQRSContext(DbContextOptions<CQRSContext> options):base(options)
        {
        }
    }
}
