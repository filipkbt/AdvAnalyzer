using AdvAnalyzer.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Repositories
{
    public interface ISearchQueryRepository
    {
        public Task<IEnumerable<SearchQuery>> GetAllByUserId(int userId);
        public Task<SearchQuery> GetById(int searchQueryId);
        public Task<SearchQuery> Insert(SearchQuery searchQuery);
        public Task<SearchQuery> Update(SearchQuery searchQuery);
        public Task<bool> Delete(int searchQueryId);

    }
}
