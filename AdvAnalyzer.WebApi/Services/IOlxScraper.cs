using AdvAnalyzer.WebApi.Dtos;
using AdvAnalyzer.WebApi.Models;
using PuppeteerSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Services
{
    public interface IOlxScraper
    {
        public Task<OlxScraperResultDto> TryParseOlx(SearchQuery searchQuery, List<string> last52AdvertisementsUrl);
    }
}
