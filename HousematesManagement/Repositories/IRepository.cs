
namespace HousemateManagement.Repositories
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAll(Guid id);
        public Task<List<T>> GetDirect(Guid id);
        public Task Delete(List<Guid> modelIds);
        public Task Update(T modelDto);
        public Task Add(T modelDto, Guid userId);
    }
}
