using AdvAnalyzer.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
        public async Task<bool> Delete(int searchQueryId)
        {
            var existing = table.Find(searchQueryId);
            table.Remove(existing);
            return  await _context.SaveChangesAsync() > 0 ? true : false;     
        }

        public async Task<SearchQuery> Insert(SearchQuery searchQuery)
        {
            searchQuery.DateAdded = DateTime.Now;
            await table.AddAsync(searchQuery);
            await _context.SaveChangesAsync();
            return searchQuery;
        }

        public async Task<SearchQuery> Update(SearchQuery searchQuery)
        {
            table.Attach(searchQuery);
            _context.Entry(searchQuery).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return searchQuery;
        }
    }
}