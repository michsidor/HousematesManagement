using HousemateManagement.Models.Payments.Repositories;
using MediatR;

namespace HousemateManagement.Models.Payments.Commands.Handler
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand>
    {
        private readonly IPaymentRepository _paymentRepository;
        public UpdatePaymentCommandHandler(IPaymentRepository advertisementRepository)
        {
            _paymentRepository = advertisementRepository;
        }

        public async Task<Unit> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            await _paymentRepository.Update(request.PaymentDto);
            return Unit.Value;
        }
    }
}