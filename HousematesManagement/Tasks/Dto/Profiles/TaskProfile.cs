using AutoMapper;
using HousemateManagement.Tasks.Dto;
using Task = Entity.Entities.Task;

namespace HousematesManagement.Tasks.Dto.NewFolder
{
    public class TaskProfile : Profile
    {
        public TaskProfile() 
        {
            CreateMap<Task, TaskDto>();
        }
    }
}