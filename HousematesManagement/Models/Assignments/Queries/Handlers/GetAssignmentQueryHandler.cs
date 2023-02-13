using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Repositories;
using MediatR;

namespace HousemateManagement.Models.Assignments.Queries.Handlers
{
    public class GetAssignmentQueryHandler : IRequestHandler<GetAssignmentQuery, List<AssignmentDto>>
    {
        private readonly IAssignmentRepository _taskRepository;
        public GetAssignmentQueryHandler(IAssignmentRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<AssignmentDto>> Handle(GetAssignmentQuery request, CancellationToken cancellationToken)
        {
            var result = await _taskRepository.GetDirect(request.Id);

            return result;
        }
    }
}
