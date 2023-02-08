using HousemateManagement.Models.Advertisements.Repositories;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Commands.Handler
{
    public class DeleteAdvertisementCommandHandler : IRequestHandler<DeleteAdvertisementCommand>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        public DeleteAdvertisementCommandHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public async Task<Unit> Handle(DeleteAdvertisementCommand request, CancellationToken cancellationToken)
        {
            await _advertisementRepository.Delete(request.ModelsIds);

            return Unit.Value;
        }
    }
}
