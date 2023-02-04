using Entity.Entities;
using Entity.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.EntitiesConfiguration
{
    internal sealed class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.Property(data => data.DateOfAddition)
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(title => title.Title)
                .IsRequired();

            builder.Property(description => description.Description)
                .IsRequired();

            builder.Property(status => status.Status)
                .HasDefaultValue(false);


            AssignmentSeed.Seed(builder);
        }
    }
}