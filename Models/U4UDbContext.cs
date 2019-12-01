using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

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

	public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
	{
	    var entries = ChangeTracker
		.Entries()
		.Where(e =>
		       (e.Entity is TimestampEntity)
		       && (e.State == EntityState.Added
			    || e.State == EntityState.Modified));

	    foreach (var entityEntry in entries)
	    {
		DateTime currentDate = DateTime.Now;
		((TimestampEntity)entityEntry.Entity).Modified = currentDate;

		if (entityEntry.State == EntityState.Added)
		{
		    ((TimestampEntity)entityEntry.Entity).Created = currentDate;
		}
		else
		{
		    entityEntry.Property("Created").IsModified = false;
		}
	    }

	    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
	}
    }
}
