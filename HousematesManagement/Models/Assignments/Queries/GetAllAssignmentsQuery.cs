using HousemateManagement.Models.Assignments.Dto;
using MediatR;

namespace HousemateManagement.Models.Assignments.Queries
{
    public class GetAllAssignmentsQuery : IRequest<List<AssignmentDto>>
    {
        public Guid Id { get; set; }
    }
}
