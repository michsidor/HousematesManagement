using Moq;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Repositories;
using HousemateManagement.Models.Assignments.Commands.Handlers;
using HousemateManagement.Models.Assignments.Commands;

namespace HousemateManagement.Tests.Endpoints.CQRSTests.AssignmentsTests
{
    public class AddAssignmentsCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_AddsAssignmentToRepository()
        {
            var assignmentDto = new AssignmentDto
            {
                Title = "Test Advertisement",
                Description = "This is a test advertisement",
                Comments = "testComment",
            };
            var userId = Guid.NewGuid();

            var mockRepository = new Mock<IAssignmentRepository>();
            var handler = new AddAssignmentCommandHandler(mockRepository.Object);
            var command = new AddAssignmentCommand()
            {
                AssigmentDto = assignmentDto,
                UserId = userId
            };

            await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.Add(assignmentDto, userId), Times.Once());
        }
    }
}