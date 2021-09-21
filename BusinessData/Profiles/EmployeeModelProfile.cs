using AutoMapper;
using BusinessData.Models;

namespace BusinessData.Profiles
{
    public class EmployeeModelProfile : Profile
    {
        public EmployeeModelProfile()
        {
            CreateMap<EmployeeModel, Domain.Entities.Employee>();

            CreateMap<Domain.Entities.Employee, EmployeeModel>()
                .ForMember(m => m.StaffMember, opt => opt.MapFrom(s => s.IsStaffMember ? "Yes" : "No"))
                .ForMember(m => m.IsStaffMember, opt => opt.Ignore());
        }
    }
}
