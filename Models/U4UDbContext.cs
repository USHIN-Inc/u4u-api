using Microsoft.EntityFrameworkCore;

namespace ushinsvc.Models
{
    public class U4UDbContext : DbContext
    {
        public U4UDbContext(DbContextOptions<U4UDbContext> options)
            : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }
	public DbSet<User> Users { get; set; }
    }
}
