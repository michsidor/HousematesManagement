using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Repositories;

namespace HousemateManagement.Models.Advertisements.Repositories
{
    public interface IAdvertisementRepository :  IRepository<AdvertisementDto>{}
}