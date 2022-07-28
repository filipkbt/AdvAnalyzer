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
        }

        public virtual DbSet<Advertisement> Advertisement { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<SearchQuery> SearchQuery { get; set; }

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
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<SearchQuery>()
                .HasMany(b => b.Advertisements)
                .WithOne(b => b.SearchQuery)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<SearchQuery>()
                .HasOne(b => b.User)
                .WithMany(b => b.SearchQueries)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
