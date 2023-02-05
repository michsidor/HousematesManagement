using HousemateManagement.Models.Advertisements.Repositories;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Commands
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeleteAdvertisementCommand>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        public DeletePaymentCommandHandler(IAdvertisementRepository advertisementRepository)
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
