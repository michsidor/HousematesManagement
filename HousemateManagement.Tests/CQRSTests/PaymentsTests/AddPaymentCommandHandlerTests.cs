using Moq;
using HousemateManagement.Models.Payments.Dto;
using HousemateManagement.Models.Payments.Commands.Handler;
using HousemateManagement.Models.Payments.Commands;
using HousemateManagement.Models.Payments.Repositories;

namespace HousemateManagement.Tests.CQRSTests.PaymentsTests
{
    public class AddPaymentCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidInput_AddsPaymentToRepository()
        {
            var paymentDto = new PaymentDto
            {
                Amount = 1,
                Deadline = DateTime.UtcNow,
                DebtorsMetadata = "test"

            };
            var userId = Guid.NewGuid();

            var mockRepository = new Mock<IPaymentRepository>();
            var handler = new AddPaymentCommandHandler(mockRepository.Object);
            var command = new AddPaymentCommand()
            {
                PaymentDto = paymentDto,
                UserId = userId
            };

            await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.Add(paymentDto, userId), Times.Once());
        }
    }
}