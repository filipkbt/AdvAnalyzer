using System.Threading.Tasks;
using AdvAnalyzer.WebApi.Helpers;
using AdvAnalyzer.WebApi.Models;
using AdvAnalyzer.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetAngularAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private IAdvertisementRepository _repository = null;
        public AdvertisementController(IAdvertisementRepository advertisementRepository)
        {
            _repository = advertisementRepository;
        }


        [HttpGet("search-query/{searchQueryId}")]
        public async Task<IActionResult> GetAllBySearchQueryId(int searchQueryId, [FromQuery] PagedListQueryParams pagedListQueryParams)
        {
            var data = await _repository.GetAllBySearchQueryId(searchQueryId, pagedListQueryParams);
            return Ok(data);
        }

        [HttpGet("favorite/{userId}")]
        public async Task<IActionResult> GetAllFavoritesByUserId(int userId, [FromQuery] PagedListQueryParams pagedListQueryParams)
        {
            var data = await _repository.GetAllFavoritesByUserId(userId, pagedListQueryParams);
            return Ok(data);
        }

        [HttpGet("all/{userId}")]
        public async Task<IActionResult> GetAllByUserId(int userId, [FromQuery] PagedListQueryParams pagedListQueryParams)
        {
            var data = await _repository.GetAllByUserId(userId, pagedListQueryParams);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Advertisement advertisement)
        {
            var data = await _repository.Update(advertisement);
            return Ok(data);
        }
    }
}