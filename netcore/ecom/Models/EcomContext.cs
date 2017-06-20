using Microsoft.EntityFrameworkCore;
 
namespace ecom.Models
{
    public class EcomContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public EcomContext(DbContextOptions<EcomContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

    }
}