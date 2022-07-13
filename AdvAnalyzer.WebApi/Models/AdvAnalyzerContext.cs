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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =.localhost\\SQLEXPRESS; Database = AdvAnalyzer; Trusted_Connection = True; Integrated Security = false; MultipleActiveResultSets = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.HasKey(e => e.AdvertisementId);

                entity.Property(e => e.AdvertisementId).HasColumnName("AdvertisementID");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(128);

                entity.Property(e => e.Salt).HasMaxLength(128);
            });
        } } }
