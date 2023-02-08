using Entity.Enums;

namespace HousemateManagement.Models.User.Dto
{
    public sealed class UserDto
    {
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
    }
}
