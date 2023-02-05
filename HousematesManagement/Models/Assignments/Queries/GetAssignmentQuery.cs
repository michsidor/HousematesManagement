using HousemateManagement.Models.Assignments.Dto;
using MediatR;

namespace HousemateManagement.Models.Assignments.Queries
{
    public class GetAssignmentQuery : IRequest<List<AssignmentDto>>
    {
        public Guid Id { get; set; }
    }
}
