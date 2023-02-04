using AutoMapper;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Repositories;
using MediatR;

namespace HousemateManagement.Models.Assignments.Queries.Handlers
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
            var assignments = await _taskRepository.GetDirect(request.Id);

            if (!assignments.Any())
            {
                throw new NotFoundException("You have not added any assignments");
            }

            var result = _mapper.Map<AssignmentDto>(assignments);

            return result;
        }
    }
}
