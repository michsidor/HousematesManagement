using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public sealed class Assignment
    {
        public Guid Id { get; set; }
        public DateTime DateOfAddition { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Comments { get; set; }
        public bool Status { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}