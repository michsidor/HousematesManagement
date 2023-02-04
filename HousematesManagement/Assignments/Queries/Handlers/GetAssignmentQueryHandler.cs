using AutoMapper;
using HousemateManagement.Exceptions;
using HousemateManagement.Tasks.Dto;
using HousemateManagement.Tasks.Queries;
using HousemateManagement.Tasks.Repositories;
using MediatR;

namespace HousematesManagement.Tasks.Queries.Handlers
{
    public class GetAssignmentQueryHandler : IRequestHandler<GetAssignmentQuery, AssignmentDto>
    {
        private readonly IAssignmentRepository _taskRepository;
        private readonly IMapper _mapper;
        public GetAssignmentQueryHandler(IAssignmentRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<AssignmentDto> Handle(GetAssignmentQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetDirect(request.Id);

            if (task == null)
            {
                throw new NotFoundException("No tasks in your family");
            }

            var result = _mapper.Map<AssignmentDto>(task);

            return result;
        }
    }
}
