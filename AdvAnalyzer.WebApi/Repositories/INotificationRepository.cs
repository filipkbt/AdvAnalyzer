using AdvAnalyzer.WebApi.Helpers;
using AdvAnalyzer.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Repositories
{
    public interface INotificationRepository
    {
        public Task<List<Notification>> GetAllNotSeenByUserId(int userId);
        public Task<PagedList<Notification>> GetAllByUserId(int userId, PagedListQueryParams pagedListQueryParams);
        public Task<Notification> InsertWithoutSave(Notification notification);
        public Task<List<Notification>> InsertMany(List<Notification> notification);
        public Task<int> SaveChangesAsync();
    }
}
