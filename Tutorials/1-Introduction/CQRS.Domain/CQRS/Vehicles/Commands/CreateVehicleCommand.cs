using CQRS.Domain.CQRS.Vehicles.Queries;
using CQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Domain.CQRS.Vehicles.Commands
{
    public class CreateVehicleCommand : IRequest<bool>
    {
        public string Brand { get; }
        public string Model { get; }
        public int CategoryId { get; }

        public CreateVehicleCommand(
                string brand,
                string model,
                int categoryId
            )
        {
            Brand = brand;
            Model = model;
            CategoryId = categoryId;
        }

    }

}
