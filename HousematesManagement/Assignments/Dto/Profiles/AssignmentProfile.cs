using AutoMapper;
using Entity.Entities;
using HousemateManagement.Tasks.Dto;

namespace HousematesManagement.Tasks.Dto.NewFolder
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