using HousemateManagement.Tasks.Dto;
using HousemateManagement.Tasks.Repositories;
using MediatR;

namespace HousemateManagement.Tasks.Queries.Handlers
{
    public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        public GetTaskQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskDto> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            return await _taskRepository.GetDirect(request.Id);
        }
    }
}
