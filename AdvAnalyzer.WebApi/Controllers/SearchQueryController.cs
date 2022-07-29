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
        private ISearchQueryRepository repository = null;
        public SearchQueryController(ISearchQueryRepository repo)
        {
            this.repository = repo;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            var data = await repository.GetAllByUserId(userId);
            return Ok(data);
        }

        [HttpGet("{searchQueryId}")]
        public async Task<IActionResult> GetById(int searchQueryId)
        {
            var data = await repository.GetById(searchQueryId);
            return Ok(data);
        }
    }
}