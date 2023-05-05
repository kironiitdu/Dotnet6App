using Microsoft.EntityFrameworkCore;
using RazorPageDemoApp.Models;
using RazorPageDemoApp.Pages;

namespace RazorPageDemoApp.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<ClientService> clientServices { get; set; }
        public DbSet<Branch> Branches { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Branch>().ToTable("Branch");

        }
    }
}
