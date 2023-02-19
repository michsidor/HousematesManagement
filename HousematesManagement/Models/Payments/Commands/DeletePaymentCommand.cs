using MediatR;

namespace HousemateManagement.Models.Payments.Commands
{
    public class DeletePaymentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}