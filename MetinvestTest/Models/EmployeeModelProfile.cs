using AutoMapper;

namespace MetinvestTest.Models
{
    public class EmployeeModelProfile : Profile
    {
        public EmployeeModelProfile()
        {
            CreateMap<EmployeeModel, Domain.Entities.Employee>();

            CreateMap<Domain.Entities.Employee, EmployeeModel>()
                .ForMember(m => m.IsStaffMember, opt => opt.MapFrom(s => s.IsStaffMember ? "Yes" : "No"));
        }
    }
}
