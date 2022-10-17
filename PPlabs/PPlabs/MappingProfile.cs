﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace PPlabs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress, opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

           // CreateMap<Employee, EmployeeDto>()
           //.ForMember(c => c.FullAddress, opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
        }
    }
}
