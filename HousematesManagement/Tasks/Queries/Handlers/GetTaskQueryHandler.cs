using HousemateManagement.Tasks.Dto;
using HousemateManagement.Tasks.Queries;
using HousemateManagement.Tasks.Repositories;
using MediatR;

namespace HousematesManagement.Tasks.Queries.Handlers
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
            var x = await _taskRepository.GetDirect(request.Id);
            return x;
        }
    }
}
