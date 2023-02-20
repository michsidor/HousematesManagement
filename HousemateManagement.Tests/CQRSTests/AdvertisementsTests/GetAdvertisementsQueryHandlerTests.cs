using HousemateManagement.Exceptions;
using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Advertisements.Queries;
using HousemateManagement.Models.Advertisements.Queries.Handler;
using HousemateManagement.Models.Advertisements.Repositories;
using Moq;

namespace HousemateManagement.Tests.CQRSTests.AdvertisementsTests
{
    public class GetAdvertisementsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_GetAllAdvertisementsToRepository()
        {
            var id = Guid.NewGuid();
            var mockRepository = new Mock<IAdvertisementRepository>();
            var handler = new GetAllAdvertisementsQueryHandler(mockRepository.Object);
            var command = new GetAllAdvertisementsQuery()
            {
                Id = id
            };
            var expectedAdvertisements = new List<AdvertisementDto>
            {
                new AdvertisementDto { Id = Guid.NewGuid(), Title = "Ad 1" },
                new AdvertisementDto { Id = Guid.NewGuid(), Title = "Ad 2" },
                new AdvertisementDto { Id = Guid.NewGuid(), Title = "Ad 3" }
            };
            mockRepository.Setup(repo => repo.GetAll(id)).ReturnsAsync(expectedAdvertisements);

            var result = await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.GetAll(id), Times.Once());
            Assert.Equal(expectedAdvertisements, result);
        }

        [Fact]
        public async Task Handle_InValidFamilyIdInput_GetAllAdvertisementsToRepository()
        {
            var id = Guid.Empty;
            var mockRepository = new Mock<IAdvertisementRepository>();
            mockRepository.Setup(repo => repo.GetAll(id)).ThrowsAsync(new NotFoundException("User is not in any family"));
            var handler = new GetAllAdvertisementsQueryHandler(mockRepository.Object);
            var command = new GetAllAdvertisementsQuery()
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
            var mockRepository = new Mock<IAdvertisementRepository>();
            var handler = new GetAllAdvertisementsQueryHandler(mockRepository.Object);
            var command = new GetAllAdvertisementsQuery()
            {
                Id = id
            };
            mockRepository.Setup(repo => repo.GetAll(id)).ThrowsAsync(new NotFoundException("You have not any advertisements in your family"));

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.GetAll(id), Times.Once());
        }

        [Fact]
        public async Task Handle_ValidInput_GetDirectAdvertisementsToRepository()
        {
            var id = Guid.NewGuid();
            var mockRepository = new Mock<IAdvertisementRepository>();
            var handler = new GetDirectAdvertisementsQueryHandler(mockRepository.Object);
            var command = new GetDirectAdvertisementsQuery()
            {
                Id = id
            };
            var expectedAdvertisements = new List<AdvertisementDto>
            {
                new AdvertisementDto { Id = Guid.NewGuid(), Title = "Ad 1" },
                new AdvertisementDto { Id = Guid.NewGuid(), Title = "Ad 2" },
                new AdvertisementDto { Id = Guid.NewGuid(), Title = "Ad 3" }
            };
            mockRepository.Setup(repo => repo.GetDirect(id)).ReturnsAsync(expectedAdvertisements);

            var result = await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.GetDirect(id), Times.Once());
            Assert.Equal(expectedAdvertisements, result);
        }

        [Fact]
        public async Task Handle_InValidOutputList_GetDirectAdvertisementsToRepository()
        {
            var id = Guid.Empty;
            var mockRepository = new Mock<IAdvertisementRepository>();
            var handler = new GetDirectAdvertisementsQueryHandler(mockRepository.Object);
            var command = new GetDirectAdvertisementsQuery()
            {
                Id = id
            };
            mockRepository.Setup(repo => repo.GetDirect(id)).ThrowsAsync(new NotFoundException("You have not added any advertisements"));

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.GetDirect(id), Times.Once());
        }
    }
}