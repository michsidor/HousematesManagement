using AutoMapper;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Payments.Dto;
using HousemateManagement.Models.Payments.Repositories;
using MediatR;

namespace HousemateManagement.Models.Payments.Queries.Handler
{
    public class GetDirectPaymentsQueryHandler : IRequestHandler<GetDirectPaymentsQuery, List<PaymentDto>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public GetDirectPaymentsQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository  = paymentRepository;
            _mapper = mapper;
        }

        public async Task<List<PaymentDto>> Handle(GetDirectPaymentsQuery request, 
            CancellationToken cancellationToken)
        {
            var payments = await _paymentRepository.GetDirect(request.Id);

            if (!payments.Any())
            {
                throw new NotFoundException("You have not added any payments");
            }

            var result = _mapper.Map<List<PaymentDto>>(payments);

            return result;
        }
    }
}
