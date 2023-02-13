using HousemateManagement.Models.Payments.Dto;
using HousemateManagement.Models.Payments.Repositories;
using MediatR;

namespace HousemateManagement.Models.Payments.Queries.Handler
{
    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, List<PaymentDto>>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetAllPaymentsQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<List<PaymentDto>> Handle(GetAllPaymentsQuery request, 
            CancellationToken cancellationToken)
        {
            var result = await _paymentRepository.GetAll(request.Id);

            return result;
        }
    }
}