using Entity.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Entity.Entities.Task;

namespace Entity.EntitiesConfiguration
{
    internal sealed class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.Property(data => data.DateOfAddition)
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(title => title.Title)
                .IsRequired();

            builder.Property(description => description.Description)
                .IsRequired();

            builder.Property(status => status.Status)
                .HasDefaultValue(false);


            TaskSeed.Seed(builder);
        }
    }
}