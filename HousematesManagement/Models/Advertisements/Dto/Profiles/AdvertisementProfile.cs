using AutoMapper;
using Entity.Entities;

namespace HousemateManagement.Models.Advertisements.Dto.Profiles
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile() 
        {
            CreateMap<AdvertisementDto,Advertisement>();
            CreateMap<Advertisement,AdvertisementDto>();
        }
    }
}
