using Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Seeds
{
    public static class AdvertisementSeed
    {
        public static void Seed(this EntityTypeBuilder<Advertisement> modelBuilder)
        {
            modelBuilder.HasData(    
                new Advertisement
                {
                    Id = Guid.NewGuid(),
                    DateOfAddition = DateTime.Now,
                    Title = "Magda title",
                    Description = "Magda Description",
                    Comments = "Magda initial comment",
                    UserId = UserSeed.GetUserGuid(1),
                },
                new Advertisement
                {
                    Id = Guid.NewGuid(),
                    DateOfAddition = DateTime.Now,
                    Title = "Mateusz Title",
                    Description = "Mateusz Description",
                    Comments = "Mateusz initial comment",
                    UserId = UserSeed.GetUserGuid(2),
                },
                new Advertisement
                {
                    Id = Guid.NewGuid(),
                    DateOfAddition = DateTime.Now,
                    Title = "Michal Title",
                    Description = "Michal Description",
                    Comments = "Michal initial comment",
                    UserId = UserSeed.GetUserGuid(0),
                });
        }
    }
}