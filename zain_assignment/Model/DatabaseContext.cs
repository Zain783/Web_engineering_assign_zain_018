using assignement.data;
using Microsoft.EntityFrameworkCore;

namespace assignement.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrolled> Enrolled { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships, constraints, etc. if needed

            // Example: Configure the primary key for the Enrolled entity
            modelBuilder.Entity<Enrolled>()
                .HasKey(e => new { e.Eid, e.Sid });

            // Example: Configure the foreign key relationship between Enrolled and Class
            modelBuilder.Entity<Enrolled>()
                .HasOne(e => e.Class)
                .WithMany(c => c.Enrolled)
                .HasForeignKey(e => e.Sid);

            // Example: Configure the foreign key relationship between Enrolled and Student
            modelBuilder.Entity<Enrolled>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrolled)
                .HasForeignKey(e => e.Sid);

            // Additional configurations can be added based on your actual model

        }

    }
}
