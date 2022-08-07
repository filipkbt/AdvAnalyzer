using AdvAnalyzer.WebApi.Helpers;
using AdvAnalyzer.WebApi.Models;
using AdvAnalyzer.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SearchQueryController : ControllerBase
    {
        private ISearchQueryRepository _repository = null;
        public SearchQueryController(ISearchQueryRepository repo)
        {
            _repository = repo;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllByUserId(int userId, [FromQuery] PagedListQueryParams pagedListQueryParams)
        {
            var data = await _repository.GetAllByUserId(userId, pagedListQueryParams);
            return Ok(data);
        }

        [HttpGet("{searchQueryId}")]
        public async Task<IActionResult> GetById(int searchQueryId)
        {
            var data = await _repository.GetById(searchQueryId);
            return Ok(data);
        }

        [HttpPost("{searchQueryId}/mark-advertisements-as-seen")]
        public async Task<IActionResult> MarkAllSearchQueryAdvertisementsAsSeen(int searchQueryId)
        {
            var data = await _repository.MarkAllSearchQueryAdvertisementsAsSeen(searchQueryId);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SearchQuery searchQuery)
        {
            var data = await _repository.Insert(searchQuery);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SearchQuery searchQuery)
        {
            var data = await _repository.Update(searchQuery);
            return Ok(data);
        }

        [HttpDelete("{searchQueryId}")]
        public async Task<IActionResult> Delete(int searchQueryId)
        {
            var data = await _repository.Delete(searchQueryId);
            return Ok(data);
        }
    }
}