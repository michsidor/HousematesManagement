using HousemateManagement.Models.Assignments.Dto;
using MediatR;

namespace HousemateManagement.Models.Assignments.Commands
{
    public class AddAssignmentCommand : IRequest
    {
        public AssignmentDto AssigmentDto { get; set; }
        public Guid UserId { get; set; }
    }
}
