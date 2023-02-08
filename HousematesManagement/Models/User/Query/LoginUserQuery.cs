using HousemateManagement.Models.User.Dto;
using MediatR;

namespace HousemateManagement.Models.User.Query
{
    public class LoginUserQuery : IRequest<Guid>
    {
        public LoginUserDto loginUserDto { get; set; }  
    }
}
