using ConstructionSubmittal_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSubmittal_API.Data
{
    //public class AppDbContext : DbContext
    //{
    //    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //    {

    //    }
    //}

    // primary constructor:
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // always call the base method first..

            // seed a few projects
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "Lockport High School",
                    ProjectNumber = "001",
                    Address = "123 Lockport Road"
                },
                new Project
                {
                    Id = 2,
                    Name = "Lockport Animal Hospital",
                    ProjectNumber = "002",
                    Address = "520 Main Street"
                },
                new Project
                {
                    Id = 3,
                    Name = "Wendys",
                    ProjectNumber = "003",
                    Address = "101 Center Drive"
                }
                );
        }
    }
}
