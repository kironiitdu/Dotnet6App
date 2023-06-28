using Microsoft.EntityFrameworkCore;
using RegistrationServerApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RegistrationServerApp.Data
{
    public class DataBaseContext : DbContext
    {


        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<User>().ToTable("TestUsers");
           

        }
    }
}
