﻿using AdvAnalyzer.WebApi.Dtos;
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
                    .Where(x => x.IsAddedAtFirstIteration == false)
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

        public async Task<PagedList<Advertisement>> GetAllFavoritesByUserId(int userId, PagedListQueryParams pagedListQueryParams)
        {
            var data = await GetAll().Where(x => x.UserId == userId)
                    .OrderBy(x => x.DateAdded)
                    .Where(x => x.IsFavorite == true)
                    .Skip(pagedListQueryParams.PageNumber * pagedListQueryParams.PageSize)
                    .Take(pagedListQueryParams.PageSize)
                    .ToListAsync();

            var count = await GetAll().Where(x => x.UserId == userId && x.IsFavorite == true).CountAsync();

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

        public async Task<List<Advertisement>> InsertMany(List<Advertisement> advertisements)
        {
            advertisements.ForEach(x => x.DateAdded = DateTime.Now);
            await table.AddRangeAsync(advertisements);
            await _context.SaveChangesAsync();
            return advertisements;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Advertisement> Update(Advertisement advertisement)
        {
            table.Attach(advertisement);
            _context.Entry(advertisement).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return advertisement;
        }

        public async Task<bool> Delete(int advertisementId)
        {
            throw new System.NotImplementedException();
        }
    }
}
