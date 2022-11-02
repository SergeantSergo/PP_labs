using AutoMapper;
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

            CreateMap<Employee, EmployeeDto>();
            CreateMap<Plan, PlanDto>();
            CreateMap<Sklad, SkladDto>();
            CreateMap<Product, ProductDto>();

            CreateMap<PlanForCreationDto, Plan>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<SkladForCreationDto, Sklad>();

            CreateMap<SkladForUpdateDto, Sklad>();
            CreateMap<PlanForUpdateDto, Plan>();
            CreateMap<ProductForUpdateDto, Product>();
            CreateMap<EmployeeForUpdateDto, Employee>();
            CreateMap<CompanyForUpdateDto, Company>();
            //patch
            CreateMap<PlanForUpdateDto, Plan>().ReverseMap();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
        }
    }
}
