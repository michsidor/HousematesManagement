using HousemateManagement.Tasks.Dto;
using MediatR;

namespace HousemateManagement.Tasks.Queries
{
    public class GetAssignmentQuery : IRequest<AssignmentDto>
    {
        public Guid Id { get; set; }
    }
}
