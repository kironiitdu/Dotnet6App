using Microsoft.EntityFrameworkCore;
using Dotnet6MVC.Models;
namespace Dotnet6MVC.Data
{
    public class HoshmandDBContext: DbContext
    {
        public HoshmandDBContext(DbContextOptions<HoshmandDBContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Users>().ToTable("Users");
            

        }
    }
}
