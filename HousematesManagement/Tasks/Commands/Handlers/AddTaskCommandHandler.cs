using HousemateManagement.Tasks.Repositories;
using MediatR;

namespace HousemateManagement.Tasks.Commands.Handlers
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;
        public AddTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            await _taskRepository.Add(request.taskDto, request.userId);

            return Unit.Value;
        }
    }
}
