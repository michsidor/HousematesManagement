using HousemateManagement.Tasks.Dto;
using MediatR;

namespace HousemateManagement.Tasks.Commands
{
    public class AddAssignmentCommand : IRequest
    {
        public AssignmentDto AssigmentDto { get; set; }
        public Guid UserId { get; set; }
    }
}
