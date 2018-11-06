using Microsoft.EntityFrameworkCore;

namespace EntityPractice1.Models
{
    public class MainContext : DbContext
    {
        public DbSet<Person> Users { get; set; }
        public MainContext(DbContextOptions<MainContext> options) : base(options) {}

    }
}