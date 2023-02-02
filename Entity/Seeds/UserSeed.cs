using Entity.Entities;
using Entity.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Seeds
{
    public static class UserSeed
    {
        private static List<Guid> _seeds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
        public static void Seed(this EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasData(
                new User{
                    Id = _seeds[0],
                    Name = "Michal",
                    SecondName = "Sidor",
                    Login = "michalSidor",
                    Email = "michalSidor@email.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("michalSidorPassword"),
                    Birthday = new DateTime(2000, 2, 13),
                    Gender = Gender.Man,
                    FamilyId = FamilySeed.GetFamilyGuid(0)
                },
                new User {
                    Id = _seeds[1],
                    Name = "Magdalena",
                    SecondName = "Jaworska-Sidor",
                    Login = "magdalenaSidor",
                    Email = "magdalenaSidor@email.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("magdalenaSidorPassword"),
                    Birthday = new DateTime(1989, 7, 14),
                    Gender = Gender.Woman,
                    FamilyId = FamilySeed.GetFamilyGuid(1)
                },
                new User {
                    Id = _seeds[2],
                    Name = "Mateusz",
                    SecondName = "Jaworski-Sidor",
                    Login = "mateuszJaworski",
                    Email = "mateuszJaworski@email.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("mateuszJaworskimagdalenaSidorPassword"),
                    Birthday = new DateTime(1985, 4, 9),
                    Gender = Gender.Man,
                    FamilyId = FamilySeed.GetFamilyGuid(1)
                });
        }
        public static Guid GetUserGuid(int element)
        {
            return _seeds[element];
        }
    }
}