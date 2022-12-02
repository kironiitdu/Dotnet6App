using DotNet6MVCWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet6MVCWebApp.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TableDateGap> TableDateGaps { get; set; }
        public DbSet<HataCozum> HataCozums { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<IdentityModel> identityModels { get; set; }
        public DbSet<ActivityItem> ActivityItems { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<UserLog> userLogs { get; set; }
    }
}
