using AdvAnalyzer.WebApi.Helpers;
using AdvAnalyzer.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Repositories
{
    public interface IAdvertisementRepository
    {
        public IQueryable<Advertisement> GetAll();
        public Task<PagedList<Advertisement>> GetAllBySearchQueryId(int searchQueryId, PagedListQueryParams pagedListQueryParams);
        public Task<List<string>> GetLast52AdvertisementsUrlBySearchQueryId(int searchQueryId);
        public Task<PagedList<Advertisement>> GetAllByUserId(int userId, PagedListQueryParams pagedListQueryParams);
        public Task<PagedList<Advertisement>> GetAllFavoritesByUserId(int userId, PagedListQueryParams pagedListQueryParams);
        public Task<Advertisement> Insert(Advertisement advertisement);
        public Task<Advertisement> InsertWithoutSave(Advertisement advertisement);
        public Task<List<Advertisement>> InsertMany(List<Advertisement> advertisements);
        public Task<int> SaveChangesAsync();
        public Task<Advertisement> Update(Advertisement advertisement);
    }
}
