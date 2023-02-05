using HousemateManagement.Models.Advertisements.Dto;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Commands
{
    public class AddAdvertisementCommand : IRequest
    {
        public Guid UserId { get; set; }
        public AdvertisementDto AdvertisementDto { get; set; }

    }
}
