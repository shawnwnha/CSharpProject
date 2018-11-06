using Microsoft.EntityFrameworkCore;

namespace LogReg.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }
        public DbSet<User> users {get;set;}    
    }
}