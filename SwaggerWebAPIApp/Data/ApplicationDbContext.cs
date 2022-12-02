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
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
           
        }

    }
}
