namespace HousemateManagement.Models.Advertisements.Dto
{
    public sealed class AdvertisementDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Comments { get; set; }
    }
}
