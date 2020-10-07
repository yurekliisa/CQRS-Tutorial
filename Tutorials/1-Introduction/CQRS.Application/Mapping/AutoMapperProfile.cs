using AutoMapper;
using CQRS.Application.Vehicles.Commands;
using CQRS.Application.Vehicles.QueryHandler.Dto;
using CQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, VehiclesDto>();
            CreateMap<CreateVehicleCommand, Vehicle>();
        }
    }
}
