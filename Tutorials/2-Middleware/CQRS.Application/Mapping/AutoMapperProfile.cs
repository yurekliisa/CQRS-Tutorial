using AutoMapper;
using CQRS.Application.Categories.Commands;
using CQRS.Application.Categories.Dto;
using CQRS.Application.Vehicles.Commands;
using CQRS.Application.Vehicles.Dto;
using CQRS.Domain.Entities;

namespace CQRS.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, VehiclesDto>();
            CreateMap<Vehicle, VehicleDetailDto>();
            CreateMap<CreateVehicleCommand, Vehicle>();
            CreateMap<UpdateVehicleCommand, Vehicle>();

            CreateMap<Category, CategoryDetailDto>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}
