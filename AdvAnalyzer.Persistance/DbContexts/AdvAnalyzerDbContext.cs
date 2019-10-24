using AdvAnalyzer.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvAnalyzer.Persistance.DbContexts
{
    public class AdvAnalyzerDbContext : IdentityDbContext
    {
        public AdvAnalyzerDbContext(DbContextOptions<AdvAnalyzerDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
