using HousemateManagement.Models.Advertisements.Dto;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Queries
{
    public class GetAllAdvertisementsQuery : IRequest<List<AdvertisementDto>>
    {
        public Guid Id { get; set; }
    }
}