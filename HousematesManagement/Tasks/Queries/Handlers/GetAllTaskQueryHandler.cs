using HousemateManagement.Tasks.Dto;
using HousemateManagement.Tasks.Queries;
using HousemateManagement.Tasks.Repositories;
using MediatR;

namespace HousematesManagement.Tasks.Queries.Handlers
{
    public class GetAllTaskQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        public GetAllTaskQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var x = await _taskRepository.GetAll(request.Id);
            return x;
        }
    }
}
