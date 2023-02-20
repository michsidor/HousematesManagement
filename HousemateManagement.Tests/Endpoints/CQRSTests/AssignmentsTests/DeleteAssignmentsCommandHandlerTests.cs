using HousemateManagement.Exceptions;
using Moq;
using HousemateManagement.Models.Assignments.Commands.Handlers;
using HousemateManagement.Models.Assignments.Commands;
using HousemateManagement.Models.Assignments.Repositories;

namespace HousemateManagement.Tests.Endpoints.CQRSTests.AssignmentsTests
{
    public class DeleteAssignmentsCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_DeleteAssignmentToRepository()
        {
            var assignmentId = Guid.NewGuid();

            var mockRepository = new Mock<IAssignmentRepository>();
            var handler = new DeleteAssignmentCommandHandler(mockRepository.Object);
            var command = new DeleteAssignmentCommand()
            {
                Id = assignmentId
            };

            await handler.Handle(command, CancellationToken.None);
            mockRepository.Verify(repo => repo.Delete(assignmentId), Times.Once());
        }

        [Fact]
        public async Task Handle_InValidInput_DeleteAssignmentToRepository()
        {
            var assignmentId = Guid.Empty;

            var mockRepository = new Mock<IAssignmentRepository>();
            mockRepository.Setup(repo => repo.Delete(assignmentId)).ThrowsAsync(new NotFoundException("Error - no task with Id found"));
            var handler = new DeleteAssignmentCommandHandler(mockRepository.Object);
            var command = new DeleteAssignmentCommand()
            {
                Id = assignmentId
            };

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.Delete(assignmentId), Times.Once());
        }
    }
}