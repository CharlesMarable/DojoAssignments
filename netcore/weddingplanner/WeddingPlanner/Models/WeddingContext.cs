using Microsoft.EntityFrameworkCore;
 
namespace WeddingPlanner.Models
{
    public class WeddingContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WeddingContext(DbContextOptions<WeddingContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Wedding> Wedding { get; set; }
        public DbSet<Guest> Guest { get; set; }
    }
}