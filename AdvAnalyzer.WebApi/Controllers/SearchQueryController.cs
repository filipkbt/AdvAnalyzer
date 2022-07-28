using AdvAnalyzer.WebApi.Models;
using AdvAnalyzer.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SearchQueryController : ControllerBase
    {
        private ISearchQueryRepository repository = null;
        public SearchQueryController(ISearchQueryRepository repo)
        {
            this.repository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetSearchQueriesByUserId(int userId)
        {
            var data = await repository.GetAllByUserId(userId);
            return Ok(data);
        }
    }
}