using HousemateManagement.Exceptions;
using Moq;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Commands.Handlers;
using HousemateManagement.Models.Assignments.Commands;
using HousemateManagement.Models.Assignments.Repositories;

namespace HousemateManagement.Tests.Endpoints.CQRSTests.AssignmentsTests
{
    public class UpdateAssignmentsCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_UpdateAssignmentToRepository()
        {
            var assignment = new AssignmentDto()
            {
                Id = Guid.NewGuid(),
                Title = "test",
                Description = "test",
                Comments = "test"
            };

            var mockRepository = new Mock<IAssignmentRepository>();
            var handler = new UpdateAssignmentCommandHandler(mockRepository.Object);
            var command = new UpdateAssignmentCommand()
            {
                AssignmentDto = assignment
            };
            await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.Update(assignment), Times.Once());
        }

        [Fact]
        public async Task Handle_InValidModelInput_UpdateAssignmentToRepository()
        {
            var assignment = new AssignmentDto() { };

            var mockRepository = new Mock<IAssignmentRepository>();
            mockRepository.Setup(repo => repo.Update(assignment)).ThrowsAsync(new ArgumentNullException(nameof(assignment)));
            var handler = new UpdateAssignmentCommandHandler(mockRepository.Object);
            var command = new UpdateAssignmentCommand()
            {
                AssignmentDto = assignment
            };

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.Update(assignment), Times.Once());
        }

        [Fact]
        public async Task Hanlde_InvalidModelIdInput_UpdateAssignmentToRepository()
        {
            var assignment = new AssignmentDto()
            {
                Id = Guid.NewGuid(),
                Title = "test",
                Description = "test",
                Comments = "test"
            };

            var mockRepository = new Mock<IAssignmentRepository>();
            mockRepository.Setup(repo => repo.Update(assignment)).ThrowsAsync(new NotFoundException("No assignment found"));
            var command = new UpdateAssignmentCommand()
            {
                AssignmentDto = assignment
            };
            var handler = new UpdateAssignmentCommandHandler(mockRepository.Object);


            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.Update(assignment), Times.Once());
        }
    }
}