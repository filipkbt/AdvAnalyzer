
using AdvAnalyzer.WebApi.Helpers;
using AdvAnalyzer.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationRepository _repository = null;
        public NotificationController(INotificationRepository repo)
        {
            _repository = repo;
        }

        [HttpGet("user/{userId}/not-seen")]
        public async Task<IActionResult> GetAllNotSeenByUserId(int userId)
        {
            var data = await _repository.GetAllNotSeenByUserId(userId);
            return Ok(data);
        }

        [HttpGet("user/{userId}/all")]
        public async Task<IActionResult> GetAllByUserId(int userId, [FromQuery] PagedListQueryParams pagedListQueryParams)
        {
            var data = await _repository.GetAllByUserId(userId, pagedListQueryParams);
            return Ok(data);
        }

        [HttpGet("user/{userId}/mark-as-seen")]
        public async Task<IActionResult> MarkAllNotificationAsSeenByUserId(int userId)
        {
            var data = await _repository.MarkAllNotificationAsSeenByUserId(userId);
            return Ok(data);
        }

        //[HttpGet("{searchQueryId}")]
        //public async Task<IActionResult> GetById(int searchQueryId)
        //{
        //    var data = await _repository.GetById(searchQueryId);
        //    return Ok(data);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(SearchQuery searchQuery)
        //{
        //    var data = await _repository.Insert(searchQuery);
        //    return Ok(data);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update(SearchQuery searchQuery)
        //{
        //    var data = await _repository.Update(searchQuery);
        //    return Ok(data);
        //}

        //[HttpDelete("{searchQueryId}")]
        //public async Task<IActionResult> Delete(int searchQueryId)
        //{
        //    var data = await _repository.Delete(searchQueryId);
        //    return Ok(data);
        //}
    }
}
