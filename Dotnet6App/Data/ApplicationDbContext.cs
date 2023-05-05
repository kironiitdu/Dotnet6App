using Dotnet6App.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6App.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<VehicleFilter> VehicleFilter { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Predoslepozicie> Predoslepozicies { get; set; }
        public DbSet<UserProfilePicture> userProfilePictures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<VehicleFilter>().ToTable("VehicleFilter");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Predoslepozicie>().ToTable("Predoslepozicie");
            modelBuilder.Entity<UserProfilePicture>().ToTable("UserProfilePicture");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<RawMaterial>().ToTable("RawMaterial");
            modelBuilder.Entity<Stock>().ToTable("Stock");
        }
       
    }
}
