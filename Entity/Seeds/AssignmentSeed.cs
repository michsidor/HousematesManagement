using Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Seeds
{
    public static class AssignmentSeed
    {
        public static void Seed(this EntityTypeBuilder<Assignment> modelBuilder)
        {
            modelBuilder.HasData(
                new Assignment
                {
                    Id = Guid.NewGuid(),
                    DateOfAddition = DateTime.Now,
                    Title = "Task title Magda",
                    Description = "Task description Magda",
                    Comments = "Initial Magda comment",
                    Status = false,
                    UserId = UserSeed.GetUserGuid(1)
                },
                new Assignment
                {
                    Id = Guid.NewGuid(),
                    DateOfAddition = DateTime.Now,
                    Title = "Task title Mateusz",
                    Description = "Task description Mateusz",
                    Comments = "Initial Mateusz comment",
                    Status = false,
                    UserId = UserSeed.GetUserGuid(2)
                },
                new Assignment
                {
                    Id = Guid.NewGuid(),
                    DateOfAddition = DateTime.Now,
                    Title = "Task title Michal",
                    Description = "Task description Michal",
                    Comments = "Initial Michal comment",
                    Status = false,
                    UserId = UserSeed.GetUserGuid(0)
                });
        }
    }
}