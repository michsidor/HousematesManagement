using HousemateManagement.Exceptions;
using HousemateManagement.Models.Advertisements.Commands.Handler;
using HousemateManagement.Models.Advertisements.Commands;
using HousemateManagement.Models.Advertisements.Repositories;
using Moq;

namespace HousemateManagement.Tests.Endpoints.CQRSTests.AdvertisementsTests
{
    public class DeleteAdvertisementsCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_DeleteAdvertisementToRepository()
        {
            var advertisementId = Guid.NewGuid();

            var mockRepository = new Mock<IAdvertisementRepository>();
            var handler = new DeleteAdvertisementCommandHandler(mockRepository.Object);
            var command = new DeleteAdvertisementCommand()
            {
                Id = advertisementId
            };

            await handler.Handle(command, CancellationToken.None);
            mockRepository.Verify(repo => repo.Delete(advertisementId), Times.Once());
        }

        [Fact]
        public async Task Handle_InValidInput_DeleteAdvertisementToRepository()
        {
            var advertisementId = Guid.Empty;

            var mockRepository = new Mock<IAdvertisementRepository>();
            mockRepository.Setup(repo => repo.Delete(advertisementId)).ThrowsAsync(new NotFoundException("Error - no task with Id found"));
            var handler = new DeleteAdvertisementCommandHandler(mockRepository.Object);
            var command = new DeleteAdvertisementCommand()
            {
                Id = advertisementId
            };

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.Delete(advertisementId), Times.Once());
        }
    }
}