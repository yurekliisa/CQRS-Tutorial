using CQRS.Application.Interfaces;
using CQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Infrastructure
{
    public static class DI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CQRSContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IContext, CQRSContext>();
            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

           
            return services;
        }
    }
}
