using HousemateManagement.Models.Payments.Dto;
using HousemateManagement.Models.Payments.Repositories;
using MediatR;

namespace HousemateManagement.Models.Payments.Queries.Handler
{
    public class GetDirectPaymentsQueryHandler : IRequestHandler<GetDirectPaymentsQuery, List<PaymentDto>>
    {
        private readonly IPaymentRepository _paymentRepository;
        public GetDirectPaymentsQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository  = paymentRepository;
        }

        public async Task<List<PaymentDto>> Handle(GetDirectPaymentsQuery request, 
            CancellationToken cancellationToken)
        {
            var result = await _paymentRepository.GetDirect(request.Id);

            return result;
        }
    }
}