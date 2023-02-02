using HousemateManagement.Tasks.Dto;

namespace HousemateManagement.Tasks.Repositories
{
    public interface ITaskRepository
    {
        public Task<IEnumerable<TaskDto>> GetAll(Guid Id);
        public Task<TaskDto> GetDirect(Guid Id);
        public Task Delete(List<Guid> TaskId);
        public Task Update(Guid TaskId, TaskDto taskDto);
        public Task Add(TaskDto taskDto, Guid userId);  
    }
}