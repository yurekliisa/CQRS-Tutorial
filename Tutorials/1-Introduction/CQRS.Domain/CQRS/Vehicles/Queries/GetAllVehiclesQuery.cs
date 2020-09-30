using CQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Domain.CQRS.Vehicles.Queries
{
    public class GetAllVehiclesQuery:IRequest<IEnumerable<Vehicle>>
    {
    }
}
