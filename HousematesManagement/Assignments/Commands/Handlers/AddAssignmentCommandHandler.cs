using HousemateManagement.Tasks.Repositories;
using MediatR;

namespace HousemateManagement.Tasks.Commands.Handlers
{
    public class AddAssignmentCommandHandler : IRequestHandler<AddAssignmentCommand>
    {
        private readonly IAssignmentRepository _taskRepository;
        public AddAssignmentCommandHandler(IAssignmentRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(AddAssignmentCommand request, CancellationToken cancellationToken)
        {
            await _taskRepository.Add(request.AssigmentDto, request.UserId);

            return Unit.Value;
        }
    }
}
