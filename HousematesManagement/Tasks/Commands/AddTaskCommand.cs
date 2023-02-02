using HousemateManagement.Tasks.Dto;
using MediatR;

namespace HousemateManagement.Tasks.Commands
{
    public class AddTaskCommand : IRequest
    {
        public TaskDto taskDto { get; set; }
        public Guid userId { get; set; }
    }
}
