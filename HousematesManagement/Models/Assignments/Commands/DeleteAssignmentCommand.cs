using MediatR;

namespace HousemateManagement.Models.Assignments.Commands
{
    public class DeleteAssignmentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
