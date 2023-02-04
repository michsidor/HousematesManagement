using Entity.Entities;
using Entity.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Entity.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }  
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Family> Families { get; set; } 
        public DbSet<Payment> Payments { get; set; } 
        public DbSet<Advertisement> Advertisements { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FamilyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        }
    }
}