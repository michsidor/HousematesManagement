using MediatR;

namespace HousemateManagement.Models.Advertisements.Commands
{
    public class DeleteAdvertisementCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
