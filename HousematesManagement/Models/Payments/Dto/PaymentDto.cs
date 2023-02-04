namespace HousemateManagement.Models.Payments.Dto
{
    public sealed class PaymentDto
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public DateTime Deadline { get; set; }
        public string DebtorsMetadata { get; set; }
    }
}
