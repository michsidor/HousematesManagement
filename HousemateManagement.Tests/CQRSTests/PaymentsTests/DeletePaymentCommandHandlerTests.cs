using HousemateManagement.Exceptions;
using Moq;
using HousemateManagement.Models.Payments.Repositories;
using HousemateManagement.Models.Payments.Commands.Handler;
using HousemateManagement.Models.Payments.Commands;

namespace HousemateManagement.Tests.CQRSTests.PaymentsTests
{
    public class DeletePaymentCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_DeletePaymentToRepository()
        {
            var paymentId = Guid.NewGuid();

            var mockRepository = new Mock<IPaymentRepository>();
            var handler = new DeletePaymentCommandHandler(mockRepository.Object);
            var command = new DeletePaymentCommand()
            {
                Id = paymentId
            };

            await handler.Handle(command, CancellationToken.None);
            mockRepository.Verify(repo => repo.Delete(paymentId), Times.Once());
        }

        [Fact]
        public async Task Handle_InValidInput_DeletePaymentToRepository()
        {
            var paymentId = Guid.Empty;

            var mockRepository = new Mock<IPaymentRepository>();
            mockRepository.Setup(repo => repo.Delete(paymentId)).ThrowsAsync(new NotFoundException("No payment found"));
            var handler = new DeletePaymentCommandHandler(mockRepository.Object);
            var command = new DeletePaymentCommand()
            {
                Id = paymentId
            };

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.Delete(paymentId), Times.Once());
        }
    }
}