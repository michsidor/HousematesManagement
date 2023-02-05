using HousemateManagement.Models.Payments.Dto;
using MediatR;

namespace HousemateManagement.Models.Payments.Commands
{
    public class UpdatePaymentCommand : IRequest
    {
        public PaymentDto PaymentDto { get; set; }
    }
}