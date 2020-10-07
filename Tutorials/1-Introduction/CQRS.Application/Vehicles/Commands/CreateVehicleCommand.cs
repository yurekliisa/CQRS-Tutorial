using CQRS.Application.Vehicles.CommandHandlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.Vehicles.Commands
{
    public class CreateVehicleCommand:IRequest<CreatedVehicle>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int CategoryId { get; set; }
        //public CreateVehicleCommand(
        //        string brand,
        //        string model,
        //        int categoryId
        //    )
        //{
        //    Brand = brand;
        //    Model = model;
        //    CategoryId = categoryId;
        //}
    }
}
