using AutoMapper;
using Entity.Entities;

namespace HousemateManagement.Models.Assignments.Dto.Profiles
{
    public class AssignmentProfile : Profile
    {
        public AssignmentProfile()
        {
            CreateMap<Assignment, AssignmentDto>();
            CreateMap<AssignmentDto, Assignment>();
        }
    }
}