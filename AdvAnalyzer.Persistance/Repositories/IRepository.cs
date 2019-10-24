using AdvAnalyzer.Domain.Entities;
using System.Threading.Tasks;

namespace AdvAnalyzer.Persistance.Repositories
{
    public interface IRepository<T> where T : AggregateRoot
    {
        Task AddAsync(T entity);
        Task<bool> SaveAsync();
    }
}
