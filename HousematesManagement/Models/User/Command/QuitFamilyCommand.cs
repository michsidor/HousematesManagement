using MediatR;

namespace HousemateManagement.Models.User.Command
{
    public class QuitFamilyCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
