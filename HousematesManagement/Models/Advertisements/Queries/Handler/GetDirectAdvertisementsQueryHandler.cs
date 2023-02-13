using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Advertisements.Repositories;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Queries.Handler
{
    public class GetDirectAdvertisementsQueryHandler : IRequestHandler<GetDirectAdvertisementsQuery, List<AdvertisementDto>>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        public GetDirectAdvertisementsQueryHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public async Task<List<AdvertisementDto>> Handle(GetDirectAdvertisementsQuery request, 
            CancellationToken cancellationToken)
        {
            var result = await _advertisementRepository.GetDirect(request.Id);

            return result;
        }
    }
}