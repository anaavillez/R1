using Microsoft.EntityFrameworkCore;
using R1.Core;

namespace R1.Data
{
    public class R1DbContext : DbContext
    {
        public R1DbContext(DbContextOptions<R1DbContext> options)
    : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
