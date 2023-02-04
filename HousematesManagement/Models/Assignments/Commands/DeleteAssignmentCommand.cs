using MediatR;

namespace HousemateManagement.Models.Assignments.Commands
{
    public class DeleteAssignmentCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
