namespace AdvAnalyzer.WebApi.Controllers
{
    using System.Threading.Tasks;
    using AdvAnalyzer.WebApi.Dtos;
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
        public class DashboardController : ControllerBase
        {
            private IChartRepository _chartRepository;
            public DashboardController(IChartRepository chartRepository)
            {
                _chartRepository = chartRepository;
            }


            [HttpGet("chart/advertisements-by-date-added/{userId}")]
            public async Task<IActionResult> GetLineChartAdvertisementsByDateAdded(int userId)
            {
                var data = await _chartRepository.GetLineChartAdvertisementsByDateAdded(userId);
                ChartDataDto chartData = new ChartDataDto() { ChartData = data.ChartData };
                return Ok(chartData);
            }
        }
    }
}
