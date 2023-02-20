using HousemateManagement.Exceptions;
using Moq;
using HousemateManagement.Models.Payments.Dto;
using HousemateManagement.Models.Payments.Repositories;
using HousemateManagement.Models.Payments.Commands.Handler;
using HousemateManagement.Models.Payments.Commands;

namespace HousemateManagement.Tests.Endpoints.CQRSTests.PaymentsTests
{
    public class UpdatePaymentCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_UpdatePaymentToRepository()
        {
            var payment = new PaymentDto()
            {
                Id = Guid.NewGuid(),
                Amount = 1,
                Deadline = DateTime.Now,
                DebtorsMetadata = "test"
            };

            var mockRepository = new Mock<IPaymentRepository>();
            var handler = new UpdatePaymentCommandHandler(mockRepository.Object);
            var command = new UpdatePaymentCommand()
            {
                PaymentDto = payment
            };
            await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.Update(payment), Times.Once());
        }

        [Fact]
        public async Task Handle_InValidModelInput_UpdatePaymentToRepository()
        {
            var payment = new PaymentDto() { };

            var mockRepository = new Mock<IPaymentRepository>();
            mockRepository.Setup(repo => repo.Update(payment)).ThrowsAsync(new ArgumentNullException(nameof(payment)));
            var handler = new UpdatePaymentCommandHandler(mockRepository.Object);
            var command = new UpdatePaymentCommand()
            {
                PaymentDto = payment
            };

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.Update(payment), Times.Once());
        }

        [Fact]
        public async Task Hanlde_InvalidModelIdInput_UpdatePaymentToRepository()
        {
            var payment = new PaymentDto()
            {
                Id = Guid.NewGuid(),
                Amount = 1,
                Deadline = DateTime.Now,
                DebtorsMetadata = "test"
            };

            var mockRepository = new Mock<IPaymentRepository>();
            mockRepository.Setup(repo => repo.Update(payment)).ThrowsAsync(new NotFoundException("No payment found"));
            var command = new UpdatePaymentCommand()
            {
                PaymentDto = payment
            };
            var handler = new UpdatePaymentCommandHandler(mockRepository.Object);


            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));

            mockRepository.Verify(repo => repo.Update(payment), Times.Once());
        }
    }
}