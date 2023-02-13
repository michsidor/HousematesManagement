using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Repositories;
using MediatR;

namespace HousemateManagement.Models.Assignments.Queries.Handlers
{
    public class GetAllAssignmentsQueryHandler : IRequestHandler<GetAllAssignmentsQuery, List<AssignmentDto>>
    {
        private readonly IAssignmentRepository _taskRepository;
        public GetAllAssignmentsQueryHandler(IAssignmentRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<AssignmentDto>> Handle(GetAllAssignmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _taskRepository.GetAll(request.Id);

            return result;
        }
    }
}