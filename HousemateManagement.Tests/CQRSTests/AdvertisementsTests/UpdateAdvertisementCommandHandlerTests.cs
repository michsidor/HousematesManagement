using HousemateManagement.Exceptions;
using HousemateManagement.Models.Advertisements.Commands.Handler;
using HousemateManagement.Models.Advertisements.Commands;
using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Advertisements.Repositories;
using Moq;

namespace HousemateManagement.Tests.CQRSTests.AdvertisementsTests
{
    public class UpdateAdvertisementCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_UpdateAdvertisementToRepository()
        {
            var advertisement = new AdvertisementDto()
            {
                Id = Guid.NewGuid(),
                Title = "test",
                Description = "test",
                Comments = "test"
            };

            var mockRepository = new Mock<IAdvertisementRepository>();
            var handler = new UpdateAdvertisementCommandHandler(mockRepository.Object);
            var command = new UpdateAdvertisementCommand()
            {
                AdvertisementDto = advertisement
            };
            await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.Update(advertisement), Times.Once());
        }

        [Fact]
        public async Task Handle_InValidModelInput_UpdateAdvertisementToRepository()
        {
            var advertisement = new AdvertisementDto() { };

            var mockRepository = new Mock<IAdvertisementRepository>();
            mockRepository.Setup(repo => repo.Update(advertisement)).ThrowsAsync(new ArgumentNullException(nameof(advertisement)));
            var handler = new UpdateAdvertisementCommandHandler(mockRepository.Object);
            var command = new UpdateAdvertisementCommand()
            {
                AdvertisementDto = advertisement
            };

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.Update(advertisement), Times.Once());
        }

        [Fact]
        public async Task Hanlde_InvalidModelIdInput_UpdateAdvertisementToRepository()
        {
            var advertisement = new AdvertisementDto()
            {
                Id = Guid.Empty,
                Title = "test",
                Description = "test",
                Comments = "test"
            };

            var mockRepository = new Mock<IAdvertisementRepository>();
            mockRepository.Setup(repo => repo.Update(advertisement)).ThrowsAsync(new NotFoundException("Error - no task with Id found"));
            var command = new UpdateAdvertisementCommand()
            {
                AdvertisementDto = advertisement
            };
            var handler = new UpdateAdvertisementCommandHandler(mockRepository.Object);


            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.Update(advertisement), Times.Once());
        }
    }
}