using HousemateManagement.Models.Advertisements.Dto;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Queries
{
    public class GetDirectAdvertisementsQuery : IRequest<List<AdvertisementDto>>
    {
        public Guid Id { get; set; }
    }
}
