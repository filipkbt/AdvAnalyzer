using AdvAnalyzer.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Repositories
{

    public class SearchQueryRepository : ISearchQueryRepository
    {
        private readonly AdvAnalyzerContext _context;
        private DbSet<SearchQuery> table = null;

        public SearchQueryRepository(AdvAnalyzerContext context)
        {
            _context = context;
            table = _context.Set<SearchQuery>();
        }

        public IQueryable<SearchQuery> GetAll()
        {
            return table.AsQueryable();
        }

        public async Task<IEnumerable<SearchQuery>> GetAllByUserId(int userId)
        {
            return await GetAll().Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<SearchQuery> GetById(int searchQueryId)
        {
            return await table.FindAsync(searchQueryId);

        }
        public Task<bool> Delete(int searchQueryId)
        {
            throw new System.NotImplementedException();
        }

        public Task<SearchQuery> Insert(SearchQuery searchQuery)
        {
            throw new System.NotImplementedException();
        }

        public Task<SearchQuery> Update(SearchQuery searchQuery)
        {
            throw new System.NotImplementedException();
        }
    }
}



    //public IQueryable<T> GetAll()
    //{
    //    return this.table.AsQueryable();
    //}

//public async Task<IEnumerable<T>> GetAllByUserId<TKey>(TKey userId)
//{
//    return await table.FindAsync(userId);
//}
//public async Task<T> GetById(int id)
//{
//    return await table.FindAsync(id);
//}
//public void Insert(T obj)
//{
//    table.Add(obj);
//}
//public void Update(T obj)
//{
//    table.Attach(obj);
//    _context.Entry(obj).State = EntityState.Modified;
//}
//public void Delete(int id)
//{
//    T existing = table.Find(id);
//    table.Remove(existing);
//}
//public void Save()
//{
//    _context.SaveChanges();
//}