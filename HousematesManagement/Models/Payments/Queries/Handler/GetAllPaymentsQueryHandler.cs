using AutoMapper;
using HousemateManagement.Exceptions;
using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Advertisements.Repositories;
using HousemateManagement.Models.Payments.Dto;
using HousemateManagement.Models.Payments.Repositories;
using MediatR;

namespace HousemateManagement.Models.Payments.Queries
{
    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, List<PaymentDto>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetAllPaymentsQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<List<PaymentDto>> Handle(GetAllPaymentsQuery request, 
            CancellationToken cancellationToken)
        {
            var payments = await _paymentRepository.GetDirect(request.Id);

            if (!payments.Any())
            {
                throw new NotFoundException("You have not any payments in your family");
            }

            var result = _mapper.Map<List<PaymentDto>>(payments);

            return result;
        }
    }
}