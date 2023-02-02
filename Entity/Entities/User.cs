using Entity.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public sealed class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Task>? Tasks { get; set; }
        public ICollection<Advertisement>? Advertisements { get; set; }
        public ICollection<Payment>? Payments { get; set; }

        [ForeignKey("Family")]
        public Guid FamilyId { get; set; }
        public Family? Family { get; set; }
    }
}