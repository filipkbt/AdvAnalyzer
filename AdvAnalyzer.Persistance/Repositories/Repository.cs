using AdvAnalyzer.Domain.Entities;
using AdvAnalyzer.Persistance.DbContexts;
using System.Threading.Tasks;

namespace AdvAnalyzer.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        protected AdvAnalyzerDbContext _dbContext;
        public Repository(AdvAnalyzerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
