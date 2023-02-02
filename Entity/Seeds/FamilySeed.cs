using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Seeds
{
    public static class FamilySeed
    {
        private static List<Guid> _seeds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid()};

        public static void Seed(this EntityTypeBuilder<Family> builder)
        {
            builder.HasData(
                new Family
                {
                    Id = _seeds[0],
                    Name = "Sidor",
                },
                new Family
                {
                    Id = _seeds[1],
                    Name = "Jaworscy-Sidor",
                });
        }

        public static Guid GetFamilyGuid(int element)
        {
            return _seeds[element];
        }
    }
}