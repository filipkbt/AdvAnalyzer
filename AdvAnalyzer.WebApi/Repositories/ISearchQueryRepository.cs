using AdvAnalyzer.WebApi.Dtos;
using AdvAnalyzer.WebApi.Helpers;
using AdvAnalyzer.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Repositories
{
    public interface ISearchQueryRepository
    {
        public IQueryable<SearchQuery> GetAll();
        public IQueryable<Advertisement> GetAllAdvertisements();

        public Task<PagedList<SearchQueryDto>> GetAllByUserId(int userId, PagedListQueryParams pagedListQueryParams);
        public Task<List<SearchQuery>> GetAllByRefreshFrequencyInMinutes(int refreshFrequencyInMinutes);
        public Task<SearchQuery> GetById(int searchQueryId);
        public Task<SearchQuery> Insert(SearchQuery searchQuery);
        public Task<SearchQuery> Update(SearchQuery searchQuery);
        public Task<SearchQuery> UpdateWithoutSave(SearchQuery searchQuery);
        public Task<int> SaveChangesAsync();
        public Task<bool> Delete(int searchQueryId);

    }
}
