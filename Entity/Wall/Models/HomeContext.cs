using Microsoft.EntityFrameworkCore;

namespace Wall.Models{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options) { }
        public DbSet<User> users {get;set;} 
        public DbSet<Message> messages {get;set;} 
        public DbSet<Comment> comments {get;set;} 
    }
}