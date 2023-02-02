using Entity.Entities;
using Entity.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.EntitiesConfiguration
{
    internal sealed class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.Property(name => name.Name)
                .HasMaxLength(100)
                .IsRequired();

            FamilySeed.Seed(builder);
        }
    }
}