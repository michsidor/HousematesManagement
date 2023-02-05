using HousemateManagement.Models.Payments.Dto;
using MediatR;

namespace HousemateManagement.Models.Payments.Queries
{
    public class GetDirectPaymentsQuery : IRequest<List<PaymentDto>>
    {
        public Guid Id { get; set; }
    }
}