using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public sealed class Payment
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public DateTime Deadline { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string? DebtorsMetadata { get; set; }
    }
}