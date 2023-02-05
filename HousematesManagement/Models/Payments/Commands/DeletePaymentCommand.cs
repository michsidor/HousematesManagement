using MediatR;

namespace HousemateManagement.Models.Payments.Commands
{
    public class DeletePaymentCommand : IRequest
    {
        public List<Guid> ModelsIds { get; set; }
    }
}