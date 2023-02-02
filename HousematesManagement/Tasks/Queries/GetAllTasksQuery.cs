using HousemateManagement.Tasks.Dto;
using MediatR;

namespace HousemateManagement.Tasks.Queries
{
    public class GetAllTasksQuery : IRequest<List<TaskDto>>
    {
        public Guid Id { get; set; }    
    }
}
