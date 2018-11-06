using Microsoft.EntityFrameworkCore;

namespace Scheduler.Models{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options) { }
        public DbSet<User> users {get;set;} 
        public DbSet<Wedding> weddings {get;set;} 
        public DbSet<Joint> joints {get;set;} 
    }
}