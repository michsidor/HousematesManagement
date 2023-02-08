using AutoMapper;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Advertisements.Repositories;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Queries.Handler
{
    public class GetAllAdvertisementsQueryHandler : IRequestHandler<GetAllAdvertisementsQuery, List<AdvertisementDto>>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IMapper _mapper;

        public GetAllAdvertisementsQueryHandler(IAdvertisementRepository advertisedRepository, IMapper mapper)
        {
            _mapper = mapper;
            _advertisementRepository = advertisedRepository;
        }

        public async Task<List<AdvertisementDto>> Handle(GetAllAdvertisementsQuery request, 
            CancellationToken cancellationToken)
        {
            var advertisements = await _advertisementRepository.GetDirect(request.Id);

            if (!advertisements.Any())
            {
                throw new NotFoundException("You have not any advertisements in your family");
            }

            var result = _mapper.Map<List<AdvertisementDto>>(advertisements);

            return result;
        }
    }
}
