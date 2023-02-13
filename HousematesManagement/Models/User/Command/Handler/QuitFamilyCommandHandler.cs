using HousemateManagement.Models.User.Repository;
using MediatR;

namespace HousemateManagement.Models.User.Command.Handler
{
    public class QuitFamilyCommandHandler : IRequestHandler<QuitFamilyCommand>
    {
        private readonly IUserRepository _userRepository;
        public QuitFamilyCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(QuitFamilyCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.Quit(request.Id);
            return Unit.Value;
        }
    }
}
