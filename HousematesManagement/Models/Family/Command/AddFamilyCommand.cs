using HousemateManagement.Models.Family.Dto;
using MediatR;

namespace HousemateManagement.Models.Family.Command
{
    public class AddFamilyCommand : IRequest
    {
        public AddFamilyDto ModelDto { get; set; }
        public Guid UserId { get; set; }
    }
}
