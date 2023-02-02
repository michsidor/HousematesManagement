using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Seeds
{
    public static class PaymentSeed
    {
        public static void Seed(this EntityTypeBuilder<Payment> modelBuilder)
        {
            modelBuilder.HasData(
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Amount = 100,
                    Deadline = new DateTime(2023, 12, 31),
                    UserId = UserSeed.GetUserGuid(0),
                    DebtorsMetadata = "John Doe"
                },
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Amount = 50,
                    Deadline = new DateTime(2023, 11, 30),
                    UserId = UserSeed.GetUserGuid(1),
                    DebtorsMetadata = UserSeed.GetUserGuid(2).ToString()
                },
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Amount = 75,
                    Deadline = new DateTime(2023, 10, 31),
                    UserId = UserSeed.GetUserGuid(1),
                    DebtorsMetadata = UserSeed.GetUserGuid(2).ToString()
                });
        }
    }
}