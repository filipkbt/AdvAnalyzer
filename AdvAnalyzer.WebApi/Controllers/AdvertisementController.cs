using System.Threading.Tasks;
using AdvAnalyzer.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetAngularAuth.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly AdvAnalyzerContext _context;
        public AdvertisementController(AdvAnalyzerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdvertisements()
        {
            var data = await _context.Advertisement.ToListAsync();
            return Ok(data);
        }
    }
}