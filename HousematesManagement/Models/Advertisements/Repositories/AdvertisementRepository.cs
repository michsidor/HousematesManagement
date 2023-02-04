using Entity.Entities;
using HousemateManagement.Models.Advertisements.Dto;

namespace HousemateManagement.Models.Advertisements.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        public Task Add(AdvertisementDto modelDto, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task Delete(List<Guid> modelIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Advertisement> GetDirect(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(AdvertisementDto modelDto)
        {
            throw new NotImplementedException();
        }
    }
}