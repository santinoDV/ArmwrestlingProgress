using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
                .HasOne(ex => ex.User)
                .WithMany(ex => ex.Exercises)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Exercise)
                .WithMany(n => n.Notes)
                .HasForeignKey(n => n.ExerciseId);
        }

    }
}
