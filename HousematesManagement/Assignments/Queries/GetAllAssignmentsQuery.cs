using HousemateManagement.Tasks.Dto;
using MediatR;

namespace HousemateManagement.Tasks.Queries
{
    public class GetAllAssignmentsQuery : IRequest<List<AssignmentDto>>
    {
        public Guid Id { get; set; }    
    }
}
