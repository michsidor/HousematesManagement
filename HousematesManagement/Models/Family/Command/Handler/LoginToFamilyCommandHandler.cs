using HousemateManagement.Models.Family.Repository;
using MediatR;

namespace HousemateManagement.Models.Family.Command.Handler
{
    public class LoginToFamilyCommandHandler : IRequestHandler<LoginToFamilyCommand>
    {
        private readonly IFamilyRepository _familyRepository;
        public LoginToFamilyCommandHandler(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }
        public async Task<Unit> Handle(LoginToFamilyCommand request, CancellationToken cancellationToken)
        {
            await _familyRepository.Login(request.ModelDto, request.UserId);

            return Unit.Value;
        }
    }
}
