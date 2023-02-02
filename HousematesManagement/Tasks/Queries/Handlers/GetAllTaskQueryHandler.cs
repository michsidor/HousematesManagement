using HousemateManagement.Tasks.Dto;
using HousemateManagement.Tasks.Repositories;
using MediatR;

namespace HousemateManagement.Tasks.Queries.Handlers
{
    public class GetAllTaskQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        public GetAllTaskQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _taskRepository.GetAll(request.Id);
        }
    }
}
