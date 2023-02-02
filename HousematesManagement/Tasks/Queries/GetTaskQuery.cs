using HousemateManagement.Tasks.Dto;
using MediatR;

namespace HousemateManagement.Tasks.Queries
{
    public class GetTaskQuery : IRequest<TaskDto>
    {
        public Guid Id { get; set; }
    }
}
