using HousemateManagement.Tasks.Dto;
using MediatR;

namespace HousemateManagement.Tasks.Commands
{
    public class UpdateTaskCommand : IRequest
    {
        public Guid Id { get; set; }
        public TaskDto taskDto { get; set; }    
    }
}