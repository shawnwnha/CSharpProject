using Microsoft.EntityFrameworkCore;

namespace BankAccount.Models
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options) { }
        public DbSet<User> users {get;set;} 
        public DbSet<Book> books {get;set;}   
    }
}