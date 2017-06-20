using Microsoft.EntityFrameworkCore;
 
namespace Restauranter.Models
{
    public class RestaurantContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }
        public DbSet<Reviews> reviews { get; set; }
    }
}