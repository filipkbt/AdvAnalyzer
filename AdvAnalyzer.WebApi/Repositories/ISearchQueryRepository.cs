using AdvAnalyzer.WebApi.Dtos;
using AdvAnalyzer.WebApi.Helpers;
using AdvAnalyzer.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Repositories
{
    public interface ISearchQueryRepository
    {
        public Task<PagedList<SearchQueryDto>> GetAllByUserId(int userId, PagedListQueryParams pagedListQueryParams);
        public Task<SearchQuery> GetById(int searchQueryId);
        public Task<SearchQuery> Insert(SearchQuery searchQuery);
        public Task<SearchQuery> Update(SearchQuery searchQuery);
        public Task<bool> Delete(int searchQueryId);

    }
}
