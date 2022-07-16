using DotNet6MVCWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet6MVCWebApp.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TableDateGap> TableDateGaps { get; set; }
        public DbSet<HataCozum> HataCozums { get; set; }
        public DbSet<Member> Members { get; set; }
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().ToTable("Animal");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<TableDateGap>().ToTable("TableDateGap");
            modelBuilder.Entity<HataCozum>().ToTable("HataCozum");
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Member>().ToTable("Member");

        }
    }
}
