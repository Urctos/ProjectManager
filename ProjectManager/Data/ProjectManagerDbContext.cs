using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Models;

namespace ProjectManager.Data
{
    public class ProjectManagerDbContext : DbContext
    {
        public ProjectManagerDbContext(DbContextOptions<ProjectManagerDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTask>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTasks)
                .HasForeignKey(pt => pt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .Property(p => p.CreateDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Project>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Project>()
                .Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            modelBuilder.Entity<ProjectTask>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<ProjectTask>()
                .Property(p => p.Description)
                .IsRequired(false);

            modelBuilder.Entity<ProjectTask>()
                .Property(p => p.IsCompleted)
                .IsRequired();


            
        }
    }
}
