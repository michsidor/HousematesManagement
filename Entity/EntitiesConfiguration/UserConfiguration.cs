using Entity.Entities;
using Entity.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.EntitiesConfiguration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(login => login.Login)
                .IsUnique();

            builder.HasIndex(email => email.Email)
                .IsUnique();

            builder.Property(name => name.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(password => password.Password)
                .IsRequired();

            builder.Property(login => login.Login)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(email => email.Email)
                .HasMaxLength(100)  
                .IsRequired();

            builder.Property(birthday => birthday.Birthday)
                .IsRequired();

            UserSeed.Seed(builder);
        }
    }
}