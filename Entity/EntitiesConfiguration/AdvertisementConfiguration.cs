using Entity.Entities;
using Entity.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.EntitiesConfiguration
{
    internal sealed class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(data => data.DateOfAddition)
                .HasDefaultValue(DateTime.Now);
            builder.Property(title => title.Title)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(description => description.Description)
                .IsRequired();

            AdvertisementSeed.Seed(builder);
        }
    }
}