using HousemateManagement.Models.Advertisements.Dto;
using HousemateManagement.Models.Payments.Dto;
using MediatR;

namespace HousemateManagement.Models.Payments.Queries
{
    public class GetAllPaymentsQuery : IRequest<List<PaymentDto>>
    {
        public Guid Id { get; set; }
    }
}