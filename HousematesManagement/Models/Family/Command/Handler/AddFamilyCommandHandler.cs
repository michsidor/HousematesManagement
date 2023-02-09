using HousemateManagement.Models.Family.Repository;
using MediatR;

namespace HousemateManagement.Models.Family.Command.Handler
{
    public class AddFamilyCommandHandler : IRequestHandler<AddFamilyCommand>
    {
        private readonly IFamilyRepository _familyRepository;
        public AddFamilyCommandHandler(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }
        public async Task<Unit> Handle(AddFamilyCommand request, CancellationToken cancellationToken)
        {
            await _familyRepository.Add(request.ModelDto, request.UserId);

            return Unit.Value;
        }
    }
}
