using Entity.Entities;
using Entity.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.EntitiesConfiguration
{
    internal sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(amount => amount.Amount)
                .IsRequired();

            builder.Property(deadline => deadline.Deadline)
                .IsRequired();

            builder.Property(debtors => debtors.DebtorsMetadata)
                .IsRequired();             
            
            PaymentSeed.Seed(builder);
        }
    }
}