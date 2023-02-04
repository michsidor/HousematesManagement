using HousemateManagement.Tasks.Repositories;
using MediatR;

namespace HousemateManagement.Tasks.Commands.Handlers
{
    public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand>
    {
        private readonly IAssignmentRepository _taskRepository;
        public UpdateAssignmentCommandHandler(IAssignmentRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
        {
            await _taskRepository.Update(request.AssignmentDto);

            return Unit.Value;
        }
    }
}
