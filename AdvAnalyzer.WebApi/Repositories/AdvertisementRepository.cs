using AdvAnalyzer.WebApi.Dtos;
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
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly AdvAnalyzerContext _context;
        private DbSet<Advertisement> table = null;
        private IMapper _mapper = null;

        public AdvertisementRepository(AdvAnalyzerContext context, IMapper mapper)
        {
            _context = context;
            table = _context.Set<Advertisement>();
            _mapper = mapper;
        }

        public IQueryable<Advertisement> GetAll()
        {
            return table.AsQueryable();
        }

        public async Task<PagedList<Advertisement>> GetAllBySearchQueryId(int searchQueryId, PagedListQueryParams pagedListQueryParams)
        {
            var data = await GetAll().Where(x => x.SearchQueryId == searchQueryId)
                    .OrderBy(x => x.DateAdded)
                    .Skip(pagedListQueryParams.PageNumber * pagedListQueryParams.PageSize)
                    .Take(pagedListQueryParams.PageSize)
                    .ToListAsync();

            var count = await GetAll().Where(x => x.SearchQueryId == searchQueryId).CountAsync();

            return new PagedList<Advertisement> { Count = count, Data = data };
        }

        public async Task<List<string>> GetLast52AdvertisementsUrlBySearchQueryId(int searchQueryId)
        {
            var data = await GetAll().Where(x => x.SearchQueryId == searchQueryId)
                    .OrderBy(x => x.DateAdded)
                    .Take(52)
                    .Select(x => x.Url)
                    .ToListAsync();

            return data;
        }

        public async Task<PagedList<Advertisement>> GetAllFavoritesByUserId(int searchQueryId, PagedListQueryParams pagedListQueryParams)
        {
            var data = await GetAll().Where(x => x.SearchQueryId == searchQueryId)
        .OrderBy(x => x.DateAdded)
        .Where(x => x.IsFavorite == true)
        .Skip(pagedListQueryParams.PageNumber * pagedListQueryParams.PageSize)
        .Take(pagedListQueryParams.PageSize)
        .ToListAsync();

            var count = await GetAll().Where(x => x.SearchQueryId == searchQueryId).CountAsync();

            return new PagedList<Advertisement> { Count = count, Data = data };
        }

        public async Task<Advertisement> Insert(Advertisement advertisement)
        {
            advertisement.DateAdded = DateTime.Now;
            await table.AddAsync(advertisement);
            await _context.SaveChangesAsync();
            return advertisement;
        }

        public async Task<Advertisement> InsertWithoutSave(Advertisement advertisement)
        {
            advertisement.DateAdded = DateTime.Now;
            await table.AddAsync(advertisement);

            return advertisement;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<Advertisement> SetIsFavorite(int advertisementId, bool isFavorite)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Delete(int advertisementId)
        {
            throw new System.NotImplementedException();
        }
    }
}
