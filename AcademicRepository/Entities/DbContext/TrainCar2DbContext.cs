using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace _2022_09_23.Entities.DbContextNamespace
{
    public class TrainCar2DbContext : DbContext 
    {
        public DbSet<TrainCar> TrainCar { get; set; }

        public DbSet<Site> Site { get; set; }

        public TrainCar2DbContext(DbContextOptions<TrainCar2DbContext> options) : base(options)
        {
            Database.SetCommandTimeout(60);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
