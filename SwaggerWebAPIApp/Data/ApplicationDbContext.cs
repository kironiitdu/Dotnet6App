using Microsoft.EntityFrameworkCore;
using SwaggerWebAPIApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SwaggerWebAPIApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Products { get; set; }
       
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<ServerNames> ServerNames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Categories>().ToTable("Categories");
            modelBuilder.Entity<Suppliers>().ToTable("Suppliers");

        }

    }
}
