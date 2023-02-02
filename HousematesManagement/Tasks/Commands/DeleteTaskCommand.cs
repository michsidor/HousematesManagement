using MediatR;

namespace HousemateManagement.Tasks.Commands
{
    public class DeleteTaskCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
