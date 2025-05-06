using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypesVM;

namespace LeaveManagementSystem.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<LeaveType, LeaveTypeReadOnlyViewModel>();
            CreateMap<LeaveTypeCreateViewModel, LeaveType>();
        }
    }
}
