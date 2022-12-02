using DotNet6MVCWebApp.Controllers;
using DotNet6MVCWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Country = DotNet6MVCWebApp.Models.Country;
using State = DotNet6MVCWebApp.Models.State;

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
        public DbSet<Student> Students { get; set; }
        public DbSet<IdentityModel> identityModels { get; set; }
        public DbSet<ActivityItem> ActivityItems { get; set; }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<UserLog> userLogs { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TaxDomainModel> taxDomainModels { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<State>().ToTable("State");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<TaxDomainModel>().ToTable("TaxDomainModel");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<TeamMember>().ToTable("TeamMember");
            modelBuilder.Entity<UserLog>().ToTable("UserLog");
            modelBuilder.Entity<Developer>().ToTable("Developer");
            modelBuilder.Entity<ActivityItem>().ToTable("ActivityItem");
            modelBuilder.Entity<Animal>().ToTable("Animal");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<TableDateGap>().ToTable("TableDateGap");
            modelBuilder.Entity<HataCozum>().ToTable("HataCozum");
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Student>().ToTable("StudentTable");
            modelBuilder.Entity<IdentityModel>().ToTable("IdentityModel");

        }
    }
}
