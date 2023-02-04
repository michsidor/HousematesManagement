using MediatR;

namespace HousemateManagement.Tasks.Commands
{
    public class DeleteAssignmentCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
