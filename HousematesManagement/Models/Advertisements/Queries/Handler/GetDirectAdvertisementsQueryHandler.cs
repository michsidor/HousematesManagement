using AutoMapper;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Advertisements.Repositories;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Queries.Handler
{
    public class GetDirectAdvertisementsQueryHandler : IRequestHandler<GetDirectAdvertisementsQuery, List<AdvertisementDto>>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IMapper _mapper;
        public GetDirectAdvertisementsQueryHandler(IAdvertisementRepository advertisementRepository, IMapper mapper)
        {
            _advertisementRepository = advertisementRepository;
            _mapper = mapper;
        }

        public async Task<List<AdvertisementDto>> Handle(GetDirectAdvertisementsQuery request, 
            CancellationToken cancellationToken)
        {
            var advertisements = await _advertisementRepository.GetDirect(request.Id);

            if (!advertisements.Any())
            {
                throw new NotFoundException("You have not added any advertisements");
            }

            var result = _mapper.Map<List<AdvertisementDto>>(advertisements);

            return result;
        }
    }
}
