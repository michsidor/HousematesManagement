using HousemateManagement.Exceptions;
using HousemateManagement.Models.Assignments.Dto;
using HousemateManagement.Models.Assignments.Queries;
using HousemateManagement.Models.Assignments.Queries.Handlers;
using HousemateManagement.Models.Assignments.Repositories;
using Moq;
namespace HousemateManagement.Tests.Endpoints.CQRSTests.AssignmentsTests
{
    public class GetAssignmentsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_GetAllAssignmentsToRepository()
        {
            var id = Guid.NewGuid();
            var mockRepository = new Mock<IAssignmentRepository>();
            var handler = new GetAllAssignmentsQueryHandler(mockRepository.Object);
            var command = new GetAllAssignmentsQuery()
            {
                Id = id
            };
            var expectedAssignments = new List<AssignmentDto>
                {
                new AssignmentDto { Id = Guid.NewGuid(), Title = "Ad 1" },
                new AssignmentDto { Id = Guid.NewGuid(), Title = "Ad 2" },
                new AssignmentDto { Id = Guid.NewGuid(), Title = "Ad 3" }
                };
            mockRepository.Setup(repo => repo.GetAll(id)).ReturnsAsync(expectedAssignments);

            var result = await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.GetAll(id), Times.Once());
            Assert.Equal(expectedAssignments, result);
        }

        [Fact]
        public async Task Handle_InValidFamilyIdInput_GetAllAdvertisementsToRepository()
        {
            var id = Guid.Empty;
            var mockRepository = new Mock<IAssignmentRepository>();
            mockRepository.Setup(repo => repo.GetAll(id)).ThrowsAsync(new NotFoundException("User is not in any family"));
            var handler = new GetAllAssignmentsQueryHandler(mockRepository.Object);
            var command = new GetAllAssignmentsQuery()
            {
                Id = id
            };

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.GetAll(id), Times.Once());
        }

        [Fact]
        public async Task Handle_InValidOutputList_GetAllAdvertisementsToRepository()
        {
            var id = Guid.Empty;
            var mockRepository = new Mock<IAssignmentRepository>();
            var handler = new GetAllAssignmentsQueryHandler(mockRepository.Object);
            var command = new GetAllAssignmentsQuery()
            {
                Id = id
            };
            mockRepository.Setup(repo => repo.GetAll(id)).ThrowsAsync(
                new NotFoundException("No assignments in your family or you are not included to family"));

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.GetAll(id), Times.Once());
        }

        [Fact]
        public async Task Handle_ValidInput_GetDirectAdvertisementsToRepository()
        {
            var id = Guid.NewGuid();
            var mockRepository = new Mock<IAssignmentRepository>();
            var handler = new GetAssignmentQueryHandler(mockRepository.Object);
            var command = new GetAssignmentQuery()
            {
                Id = id
            };
            var expectedAssignments = new List<AssignmentDto>
            {
                new AssignmentDto { Id = Guid.NewGuid(), Title = "Ad 1" },
                new AssignmentDto { Id = Guid.NewGuid(), Title = "Ad 2" },
                new AssignmentDto { Id = Guid.NewGuid(), Title = "Ad 3" }
            
            };
            mockRepository.Setup(repo => repo.GetDirect(id)).ReturnsAsync(expectedAssignments);

            var result = await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.GetDirect(id), Times.Once());
            Assert.Equal(expectedAssignments, result);
        }

        [Fact]
        public async Task Handle_InValidOutputList_GetDirectAdvertisementsToRepository()
        {
            var id = Guid.Empty;
            var mockRepository = new Mock<IAssignmentRepository>();
            var handler = new GetAssignmentQueryHandler(mockRepository.Object);
            var command = new GetAssignmentQuery()
            {
                Id = id
            };
            mockRepository.Setup(repo => repo.GetDirect(id)).ThrowsAsync(new NotFoundException("You have not added any advertisements"));

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.GetDirect(id), Times.Once());
        }
    }
}
