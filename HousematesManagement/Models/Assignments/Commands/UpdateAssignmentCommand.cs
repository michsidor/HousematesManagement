using HousemateManagement.Models.Assignments.Dto;
using MediatR;

namespace HousemateManagement.Models.Assignments.Commands
{
    public class UpdateAssignmentCommand : IRequest
    {
        public AssignmentDto AssignmentDto { get; set; }
    }
}