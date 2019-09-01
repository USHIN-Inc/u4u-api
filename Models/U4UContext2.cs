using Microsoft.EntityFrameworkCore;

namespace ushinsvc.Models
{
    public class U4UContext : DbContext
    {
        public U4UContext(DbContextOptions<U4UContext> options)
            : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    // .ValueGeneratedNever()
                    ;

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("STRING (255)");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("STRING (255)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("STRING (255)");
            });


            modelBuilder.Entity<Node>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    // .ValueGeneratedNever()
                    ;

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasColumnType("STRING (255)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("STRING (255)");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Nodes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}