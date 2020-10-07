using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.Vehicles.Commands
{
    public class DeleteVehicleCommand:IRequest
    {
        public int Id { get; set; }
    }
}
