using Entity.Entities;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Repositories;

namespace HousemateManagement.Models.Assignments.Repositories
{
    public interface IAssignmentRepository : IRepository<Assignment,AssignmentDto> {}
}