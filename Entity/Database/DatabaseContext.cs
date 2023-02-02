using Entity.Entities;
using Entity.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Task = Entity.Entities.Task;

namespace Entity.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }  
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Family> Families { get; set; } 
        public DbSet<Payment> Payments { get; set; } 
        public DbSet<Advertisement> Advertisements { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FamilyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        }
    }
}