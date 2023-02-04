using AutoMapper;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Repositories;
using MediatR;

namespace HousemateManagement.Models.Assignments.Queries.Handlers
{
    public class GetAllAssignmentsQueryHandler : IRequestHandler<GetAllAssignmentsQuery, List<AssignmentDto>>
    {
        private readonly IAssignmentRepository _taskRepository;
        private readonly IMapper _mapper;
        public GetAllAssignmentsQueryHandler(IAssignmentRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<AssignmentDto>> Handle(GetAllAssignmentsQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAll(request.Id);

            if (!tasks.Any())
            {
                throw new NotFoundException("No tasks in your family or you are not included to family");
            }

            var result = _mapper.Map<List<AssignmentDto>>(tasks);

            return result;
        }
    }
}
