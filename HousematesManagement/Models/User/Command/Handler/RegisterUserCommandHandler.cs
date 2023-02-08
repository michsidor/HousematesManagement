using HousemateManagement.Models.User.Repository;
using MediatR;
using Microsoft.Identity.Client;

namespace HousemateManagement.Models.User.Command.Handler
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository  _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }   

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.Register(request.UserDto);

            return Unit.Value;
        }
    }
}
