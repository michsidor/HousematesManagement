using HousemateManagement.Tasks.Dto;
using MediatR;

namespace HousemateManagement.Tasks.Commands
{
    public class UpdateAssignmentCommand : IRequest
    {
        public AssignmentDto AssignmentDto { get; set; }    
    }
}