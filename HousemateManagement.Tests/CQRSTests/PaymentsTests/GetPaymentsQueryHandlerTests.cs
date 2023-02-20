using HousemateManagement.Exceptions;
using Moq;
using HousemateManagement.Models.Payments.Repositories;
using HousemateManagement.Models.Payments.Queries.Handler;
using HousemateManagement.Models.Payments.Queries;
using HousemateManagement.Models.Payments.Dto;

namespace HousemateManagement.Tests.CQRSTests.PaymentsTests
{
    public class GetPaymentsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_GetAllPaymentsToRepository()
        {
            var id = Guid.NewGuid();
            var mockRepository = new Mock<IPaymentRepository>();
            var handler = new GetAllPaymentsQueryHandler(mockRepository.Object);
            var command = new GetAllPaymentsQuery()
            {
                Id = id
            };
            var expectedPayments = new List<PaymentDto>
            {
               new PaymentDto { Id = Guid.NewGuid(), Amount = 1 },
               new PaymentDto { Id = Guid.NewGuid(), Amount = 2 },
               new PaymentDto { Id = Guid.NewGuid(), Amount = 3 },
            };
            mockRepository.Setup(repo => repo.GetAll(id)).ReturnsAsync(expectedPayments);

            var result = await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.GetAll(id), Times.Once());
            Assert.Equal(expectedPayments, result);
        }

        [Fact]
        public async Task Handle_InValidFamilyIdInput_GetAllPaymentsToRepository()
        {
            var id = Guid.Empty;
            var mockRepository = new Mock<IPaymentRepository>();
            mockRepository.Setup(repo => repo.GetAll(id)).ThrowsAsync(new NotFoundException("User is not in any family"));
            var handler = new GetAllPaymentsQueryHandler(mockRepository.Object);
            var command = new GetAllPaymentsQuery()
            {
                Id = id
            };

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.GetAll(id), Times.Once());
        }

        [Fact]
        public async Task Handle_InValidOutputList_GetAllPaymentsToRepository()
        {
            var id = Guid.Empty;
            var mockRepository = new Mock<IPaymentRepository>();
            var handler = new GetAllPaymentsQueryHandler(mockRepository.Object);
            var command = new GetAllPaymentsQuery()
            {
                Id = id
            };
            mockRepository.Setup(repo => repo.GetAll(id)).ThrowsAsync(
                new NotFoundException("No payments founded"));

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.GetAll(id), Times.Once());
        }

        [Fact]
        public async Task Handle_ValidInput_GetDirectPaymentsToRepository()
        {
            var id = Guid.NewGuid();
            var mockRepository = new Mock<IPaymentRepository>();
            var handler = new GetDirectPaymentsQueryHandler(mockRepository.Object);
            var command = new GetDirectPaymentsQuery()
            {
                Id = id
            };
            var expectedPayments = new List<PaymentDto>
            {
               new PaymentDto { Id = Guid.NewGuid(), Amount = 1 },
               new PaymentDto { Id = Guid.NewGuid(), Amount = 2 },
               new PaymentDto { Id = Guid.NewGuid(), Amount = 3 },
            };
            mockRepository.Setup(repo => repo.GetDirect(id)).ReturnsAsync(expectedPayments);

            var result = await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.GetDirect(id), Times.Once());
            Assert.Equal(expectedPayments, result);
        }

        [Fact]
        public async Task Handle_InValidOutputList_GetDirectPaymentsToRepository()
        {
            var id = Guid.Empty;
            var mockRepository = new Mock<IPaymentRepository>();
            var handler = new GetDirectPaymentsQueryHandler(mockRepository.Object);
            var command = new GetDirectPaymentsQuery()
            {
                Id = id
            };
            mockRepository.Setup(repo => repo.GetDirect(id)).ThrowsAsync(new NotFoundException("No payments founded"));

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.GetDirect(id), Times.Once());
        }
    }
}