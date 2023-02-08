using HousemateManagement.Models.User.Repository;
using MediatR;

namespace HousemateManagement.Models.User.Query.Handler
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, Guid>
    {
        private IUserRepository _userRepository;
        public LoginUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.Login(request.loginUserDto);

            return result;
        }
    }
}
