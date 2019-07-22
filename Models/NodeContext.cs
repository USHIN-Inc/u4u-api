using Microsoft.EntityFrameworkCore;

namespace ushinsvc.Models
{
    public class NodeContext : DbContext
    {
        public NodeContext(DbContextOptions<NodeContext> options)
            : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }
    }
}