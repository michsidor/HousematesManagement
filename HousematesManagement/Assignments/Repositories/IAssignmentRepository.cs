using Entity.Entities;
using HousemateManagement.Tasks.Dto;

namespace HousemateManagement.Tasks.Repositories
{
    public interface IAssignmentRepository
    {
        public Task<List<Assignment>> GetAll(Guid Id);
        public Task<Assignment> GetDirect(Guid Id);
        public Task Delete(List<Guid> TaskId);
        public Task Update(AssignmentDto taskDto);
        public Task Add(AssignmentDto taskDto, Guid userId);
    }
}