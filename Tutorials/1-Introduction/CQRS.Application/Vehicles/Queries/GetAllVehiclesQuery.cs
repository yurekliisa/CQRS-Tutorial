using CQRS.Application.Vehicles.QueryHandler.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.Vehicles.Queries
{
    public class GetAllVehiclesQuery:IRequest<GetAllVehicles>
    {
    }
}
