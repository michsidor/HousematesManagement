using MediatR;

namespace HousemateManagement.Models.Advertisements.Commands
{
    public class DeleteAdvertisementCommand : IRequest
    {
        public List<Guid> ModelsIds { get; set; }
    }
}
