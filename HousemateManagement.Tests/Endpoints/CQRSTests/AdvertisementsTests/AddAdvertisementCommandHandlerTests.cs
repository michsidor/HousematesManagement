using HousemateManagement.Models.Advertisements.Commands.Handler;
using HousemateManagement.Models.Advertisements.Commands;
using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Advertisements.Repositories;
using Moq;

namespace HousemateManagement.Tests.Endpoints.CQRSTests.AdvertisementsTests
{
    public class AddAdvertisementCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_AddsAdvertisementToRepository()
        {
            var advertisementDto = new AdvertisementDto
            {
                Title = "Test Advertisement",
                Description = "This is a test advertisement",
                Comments = "testComment",
            };
            var userId = Guid.NewGuid();

            var mockRepository = new Mock<IAdvertisementRepository>();
            var handler = new AddAdvertisementCommandHandler(mockRepository.Object);
            var command = new AddAdvertisementCommand()
            {
                AdvertisementDto = advertisementDto,
                UserId = userId
            };

            await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.Add(advertisementDto, userId), Times.Once());
        }
    }
}
