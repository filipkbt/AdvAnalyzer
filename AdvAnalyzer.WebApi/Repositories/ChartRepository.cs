using AdvAnalyzer.WebApi.Dtos;
using AdvAnalyzer.WebApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace AdvAnalyzer.WebApi.Repositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly AdvAnalyzerContext _context;
        private DbSet<Advertisement> table = null;

        public ChartRepository(AdvAnalyzerContext context, IMapper mapper)
        {
            _context = context;
            table = _context.Set<Advertisement>();
        }

        public async Task<ChartDataDto> GetLineChartAdvertisementsByDateAdded(int userId)
        {
            var data = await GetAll().AsNoTracking().IncludeOptimized(x => x.SearchQuery)
                                    .Where(x => x.UserId == userId)
                                    .GroupBy(x => new { x.SearchQuery.Name, x.DateAdded.Date })
                                    .Select(y => new ChartSingleData
                                    {

                                        Name = y.Key.Name,
                                        Serie = new Serie
                                        {
                                            Value = y.Count(),
                                            Name = y.Key.Date.ToString()
                                        }
                                    }).ToListAsync();

            var chartData = data.GroupBy(x => x.Name);

            var chartDataFormatted = new ChartDataDto() { ChartData = new List<ChartSingleDataDto>()};

            foreach (var chartSingleData in chartData)
            {

                var series = chartSingleData.ToList();
                var chartSingleDataDto = new ChartSingleDataDto() { Name = chartSingleData.Key, Series = new List<Serie>() };

                foreach (var serie in series)
                {
                    chartSingleDataDto.Series.Add(serie.Serie);
                }
                chartDataFormatted.ChartData.Add(chartSingleDataDto);
            }

            return chartDataFormatted;
        }

        public IQueryable<Advertisement> GetAll()
        {
            return table.AsNoTracking().AsQueryable();
        }


    }
}
