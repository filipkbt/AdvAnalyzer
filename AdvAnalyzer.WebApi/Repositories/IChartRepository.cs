using AdvAnalyzer.WebApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Repositories
{
    public interface IChartRepository
    {
        public Task<ChartDataDto> GetLineChartAdvertisementsByDateAdded(int userId);
    }
}

