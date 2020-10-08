using CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Interfaces
{
    public interface IContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
