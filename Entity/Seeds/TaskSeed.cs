using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Entity.Entities.Task;

namespace Entity.Seeds
{
    public static class TaskSeed
    {
        public static void Seed(this EntityTypeBuilder<Task> modelBuilder)
        {
            modelBuilder.HasData(
                new Task
                {
                    Id = Guid.NewGuid(),
                    DateOfAddition = DateTime.Now,
                    Title = "Task title Magda",
                    Description = "Task description Magda",
                    Comments = "Initial Magda comment",
                    Status = false,
                    UserId = UserSeed.GetUserGuid(1)
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    DateOfAddition = DateTime.Now,
                    Title = "Task title Mateusz",
                    Description = "Task description Mateusz",
                    Comments = "Initial Mateusz comment",
                    Status = false,
                    UserId = UserSeed.GetUserGuid(2)
                },
                new Task
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