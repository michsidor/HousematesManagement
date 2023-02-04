
namespace HousemateManagement.Repositories
{
    public interface IRepository<T,TValue>
    {
        public Task<List<T>> GetAll(Guid id);
        public Task<T> GetDirect(Guid id);
        public Task Delete(List<Guid> modelIds);
        public Task Update(TValue modelDto);
        public Task Add(TValue modelDto, Guid userId);
    }
}
