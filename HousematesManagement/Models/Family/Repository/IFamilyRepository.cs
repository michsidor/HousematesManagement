using HousemateManagement.Models.Family.Dto;

namespace HousemateManagement.Models.Family.Repository
{
    public interface IFamilyRepository 
    {
        public Task Login(FamilyDto modelDto, Guid Id);
        public Task Add(AddFamilyDto modelDto, Guid userId);
    }
}