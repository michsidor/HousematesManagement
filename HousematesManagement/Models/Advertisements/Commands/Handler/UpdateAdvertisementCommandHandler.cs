using HousemateManagement.Models.Advertisements.Repositories;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Commands.Handler
{
    public class UpdateAdvertisementCommandHandler : IRequestHandler<UpdateAdvertisementCommand>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        public UpdateAdvertisementCommandHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public async Task<Unit> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            await _advertisementRepository.Update(request.AdvertisementDto);
            return Unit.Value;
        }
    }
}
