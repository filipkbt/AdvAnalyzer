using AdvAnalyzer.WebApi.Helpers;
using AdvAnalyzer.WebApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AdvAnalyzerContext _context;
        private DbSet<Notification> table = null;
        private IMapper _mapper = null;

        public NotificationRepository(AdvAnalyzerContext context, IMapper mapper)
        {
            _context = context;
            table = _context.Set<Notification>();
            _mapper = mapper;
        }

        public IQueryable<Notification> GetAll()
        {
            return table.AsQueryable();
        }

        public async Task<PagedList<Notification>> GetAllByUserId(int userId, PagedListQueryParams pagedListQueryParams)
        {
            var data = await GetAll().Where(x => x.UserId == userId)
                    .OrderByDescending(x => x.DateAdded)
                    .Skip(pagedListQueryParams.PageNumber * pagedListQueryParams.PageSize)
                    .Take(pagedListQueryParams.PageSize)
                    .ToListAsync();

            var count = await GetAll().Where(x => x.UserId == userId).CountAsync();

            return new PagedList<Notification> { Count = count, Data = data };

        }

        public async Task<List<Notification>> GetAllNotSeenByUserId(int userId)
        {
            var data = await GetAll().Where(x => x.UserId == userId && x.IsSeen == false)
                        .OrderByDescending(x => x.DateAdded)
                        .ToListAsync();

            return data;
        }

        public async Task<List<Notification>> MarkAllNotificationAsSeenByUserId(int userId)
        {
            var data = await GetAll().Where(x => x.UserId == userId && x.IsSeen == false)
                            .OrderByDescending(x => x.DateAdded)
                            .ToListAsync();

            data.ForEach(x => x.IsSeen = true);

            table.UpdateRange(data);
            await _context.SaveChangesAsync();
            return data;
        }

    public async Task<Notification> InsertWithoutSave(Notification notification)
        {
            notification.DateAdded = DateTime.Now;
            await table.AddAsync(notification);
            
            return notification;
        }

        public async Task<List<Notification>> InsertMany(List<Notification> notifications)
        {
            notifications.ForEach(x => x.DateAdded = DateTime.Now);
            await table.AddRangeAsync(notifications);
            await _context.SaveChangesAsync();
            return notifications;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
