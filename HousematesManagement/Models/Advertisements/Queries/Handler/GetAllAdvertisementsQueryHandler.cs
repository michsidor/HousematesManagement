using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Advertisements.Repositories;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Queries.Handler
{
    public class GetAllAdvertisementsQueryHandler : IRequestHandler<GetAllAdvertisementsQuery, List<AdvertisementDto>>
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public GetAllAdvertisementsQueryHandler(IAdvertisementRepository advertisedRepository)
        {
            _advertisementRepository = advertisedRepository;
        }

        public async Task<List<AdvertisementDto>> Handle(GetAllAdvertisementsQuery request, 
            CancellationToken cancellationToken)
        {
            var result = await _advertisementRepository.GetAll(request.Id);

            return result;
        }
    }
}