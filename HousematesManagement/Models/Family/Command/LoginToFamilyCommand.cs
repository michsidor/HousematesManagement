using HousemateManagement.Models.Family.Dto;
using MediatR;

namespace HousemateManagement.Models.Family.Command
{
    public class LoginToFamilyCommand : IRequest
    {
        public FamilyDto ModelDto { get; set; }
        public Guid UserId { get; set; }
    }
}
