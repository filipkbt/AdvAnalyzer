using AdvAnalyzer.WebApi.Dtos;
using AdvAnalyzer.WebApi.Helpers;
using AdvAnalyzer.WebApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace AdvAnalyzer.WebApi.Repositories
{

    public class SearchQueryRepository : ISearchQueryRepository
    {
        private readonly AdvAnalyzerContext _context;
        private DbSet<SearchQuery> table = null;
        private DbSet<Advertisement> advertisementsTable = null;
        private IMapper _mapper = null;

        public SearchQueryRepository(AdvAnalyzerContext context, IMapper mapper)
        {
            _context = context;
            table = _context.Set<SearchQuery>();
            advertisementsTable = _context.Set<Advertisement>();
            _mapper = mapper;
        }

        public IQueryable<SearchQuery> GetAll()
        {
            return table.AsNoTracking().AsQueryable();
        }

        public IQueryable<Advertisement> GetAllAdvertisements()
        {
            return advertisementsTable.AsNoTracking().AsQueryable();
        }

        public async Task<PagedList<SearchQueryDto>> GetAllByUserId(int userId, PagedListQueryParams pagedListQueryParams)
        {
            var data = await GetAll().AsNoTracking().Where(x => x.UserId == userId)
                                .OrderByDescending(x => x.DateAdded)
                                .Skip(pagedListQueryParams.PageNumber * pagedListQueryParams.PageSize)
                                .Take(pagedListQueryParams.PageSize)

                                .ToListAsync();

            var count = await GetAll().Where(x => x.UserId == userId).CountAsync();

            var searchQueryDtoList = new List<SearchQueryDto>();

            foreach (var searchQuery in data)
            {
                var searchQueryDto = _mapper.Map<SearchQuery, SearchQueryDto>(searchQuery);

                searchQueryDto.Results = await GetAllAdvertisements().AsNoTracking().Where(x => x.SearchQueryId == searchQuery.Id && x.IsAddedAtFirstIteration == false).CountAsync();
                searchQueryDto.NewResults = await GetAllAdvertisements().AsNoTracking().Where(x => x.SearchQueryId == searchQuery.Id && x.IsSeen == false && x.IsAddedAtFirstIteration == false).CountAsync();
                searchQueryDtoList.Add(searchQueryDto);
            }

            return new PagedList<SearchQueryDto> { Count = count, Data = searchQueryDtoList };

        }

        public async Task<List<SearchQuery>> GetAllByRefreshFrequencyInMinutes(int refreshFrequencyInMinutes)
        {
            var data = await GetAll().AsNoTracking().Where(x => x.RefreshFrequencyInMinutes == refreshFrequencyInMinutes)
                                .Include(x => x.User)
                                .OrderByDescending(x => x.DateAdded)
                                .ToListAsync();

            return data;
        }

        public async Task<SearchQuery> GetById(int searchQueryId)
        {
            return await table.FindAsync(searchQueryId);

        }
        public async Task<bool> Delete(int searchQueryId)
        {
            var existing = table.Find(searchQueryId);
            table.Remove(existing);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<SearchQuery> Insert(SearchQuery searchQuery)
        {
            searchQuery.DateAdded = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "Central European Standard Time");
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

        public SearchQuery UpdateWithoutSave(SearchQuery searchQuery)
        {
            searchQuery.DateAdded = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "Central European Standard Time");
            _context.Entry(searchQuery).State = EntityState.Modified;

            return searchQuery;
        }

        public async Task<List<Advertisement>> MarkAllSearchQueryAdvertisementsAsSeen(int searchQueryId)
        {
            var advertisementsNotSeen = await GetAllAdvertisements().AsNoTracking().Where(x => x.SearchQueryId == searchQueryId && x.IsSeen == false)
                    .ToListAsync();

            GetAllAdvertisements().AsNoTracking().Where(x => x.SearchQueryId == searchQueryId && x.IsSeen == false)
           .Update(x => new Advertisement() { IsSeen = true });

            return advertisementsNotSeen;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}