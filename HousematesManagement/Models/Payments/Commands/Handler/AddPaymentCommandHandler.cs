using HousemateManagement.Models.Payments.Repositories;
using MediatR;

namespace HousemateManagement.Models.Payments.Commands.Handler
{
    public class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand>
    {
        private readonly IPaymentRepository _paymentRepository;
        public AddPaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Unit> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            await _paymentRepository.Add(request.PaymentDto, request.UserId);

            return Unit.Value;
        }
    }
}