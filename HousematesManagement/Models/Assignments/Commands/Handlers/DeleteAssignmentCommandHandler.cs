using HousemateManagement.Models.Assignments.Repositories;
using MediatR;

namespace HousemateManagement.Models.Assignments.Commands.Handlers
{
    public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand>
    {
        private readonly IAssignmentRepository _taskRepository;
        public DeleteAssignmentCommandHandler(IAssignmentRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
        {
            await _taskRepository.Delete(request.Ids);

            return Unit.Value;
        }
    }
}
