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
        public DbSet<Submittal> Submittals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // always call the base method first..

            // seed a few projects
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "Lockport High School",
                    JobNumber = "001",
                    Address = "123 Lockport Road"
                },
                new Project
                {
                    Id = 2,
                    Name = "Lockport Animal Hospital",
                    JobNumber = "002",
                    Address = "520 Main Street"
                },
                new Project
                {
                    Id = 3,
                    Name = "Wendys",
                    JobNumber = "003",
                    Address = "101 Center Drive"
                }
                );

            modelBuilder.Entity<Submittal>().HasData(
                new Submittal
                {
                    Id = 1,
                    Title = "Interior Lighting : Product Data",
                    Type = Enums.SubmittalType.ProductData,
                    ProjectId = 1
                },
                new Submittal
                {
                    Id = 2,
                    Title = "Exterior Lighting : Product Data",
                    Type = Enums.SubmittalType.ProductData,
                    ProjectId = 1
                },
                new Submittal
                {
                    Id = 3,
                    Title = "Interior Lighting : Shop Drawing",
                    Type = Enums.SubmittalType.ShopDrawing,
                    ProjectId = 1
                },
                new Submittal
                {
                    Id = 4,
                    Title = "Steel Framing : Shop Drawing",
                    Type = Enums.SubmittalType.ShopDrawing,
                    ProjectId = 2
                },
                new Submittal
                {
                    Id = 5,
                    Title = "Steel Framing : Product Data",
                    Type = Enums.SubmittalType.ProductData,
                    ProjectId = 2
                }
                );
        }
    }
}
