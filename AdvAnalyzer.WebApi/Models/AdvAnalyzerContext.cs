using Microsoft.EntityFrameworkCore;

namespace AdvAnalyzer.WebApi.Models
{
    public partial class AdvAnalyzerContext : DbContext
    {
        public AdvAnalyzerContext()
        {
        }

        public AdvAnalyzerContext(DbContextOptions<AdvAnalyzerContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(9000);
        }

        public virtual DbSet<Advertisement> Advertisement { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<SearchQuery> SearchQuery { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =.localhost\\SQLEXPRESS; Database = AdvAnalyzer; Trusted_Connection = True; Integrated Security = false; MultipleActiveResultSets = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(b => b.SearchQueries)
                .WithOne(b => b.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(b => b.Notifications)
                .WithOne(b => b.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SearchQuery>()
                .HasMany(b => b.Advertisements)
                .WithOne(b => b.SearchQuery)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SearchQuery>()
                .HasOne(b => b.User)
                .WithMany(b => b.SearchQueries)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Advertisement>()
                .HasOne(b => b.SearchQuery)
                .WithMany(b => b.Advertisements)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Advertisement>()
                .HasOne(b => b.SearchQuery)
                .WithMany(b => b.Advertisements)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notification>()
                .HasOne(b => b.SearchQuery)
                .WithMany(b => b.Notifications)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notification>()
                .HasOne(b => b.User)
                .WithMany(b => b.Notifications)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
