using Microsoft.EntityFrameworkCore;

namespace RReviews.Models
{
    public class MainContext : DbContext
    {
        public DbSet<Post> posts { get; set; }
        public MainContext(DbContextOptions<MainContext> options) : base(options) {}
    }
}