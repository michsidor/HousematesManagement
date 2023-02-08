using HousemateManagement.Models.Advertisements.Repositories;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Commands.Handler
{
    public class AddAdvertisementCommandHandler : IRequestHandler<AddAdvertisementCommand>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        public AddAdvertisementCommandHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public async Task<Unit> Handle(AddAdvertisementCommand request, CancellationToken cancellationToken)
        {
            await _advertisementRepository.Add(request.AdvertisementDto, request.UserId);

            return Unit.Value;
        }
    }
}
