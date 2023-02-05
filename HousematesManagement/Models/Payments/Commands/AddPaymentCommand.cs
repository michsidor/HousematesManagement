using HousemateManagement.Models.Payments.Dto;
using MediatR;

namespace HousemateManagement.Models.Payments.Commands
{
    public class AddPaymentCommand : IRequest
    {
        public Guid UserId { get; set; }
        public PaymentDto PaymentDto { get; set; }

    }
}