using AutoMapper;
using CQRS.Application.CategoryService.Dtos;
using CQRS.Application.VehiclesService.Dtos;
using CQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, VehiclesDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
