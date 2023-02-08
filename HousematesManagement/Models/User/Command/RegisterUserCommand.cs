using HousemateManagement.Models.User.Dto;
using MediatR;

namespace HousemateManagement.Models.User.Command
{
    public class RegisterUserCommand : IRequest
    {
        public UserDto UserDto { get; set; }
    }
}
