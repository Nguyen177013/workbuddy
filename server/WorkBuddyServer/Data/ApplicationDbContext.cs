using Microsoft.EntityFrameworkCore;
using WorkBuddyServer.Entity;

namespace WorkBuddyServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Workout>? Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>()
                .HasOne(x => x.User)
                .WithMany(x => x.Workouts);
        }
    }
}
