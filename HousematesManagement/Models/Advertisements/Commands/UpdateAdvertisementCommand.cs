using HousemateManagement.Models.Advertisements.Dto;
using MediatR;

namespace HousemateManagement.Models.Advertisements.Commands
{
    public class UpdateAdvertisementCommand : IRequest
    {
        public AdvertisementDto AdvertisementDto { get; set; }
    }
}
