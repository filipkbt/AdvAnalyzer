using AdvAnalyzer.WebApi.Models;
using PuppeteerSharp;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Services
{
    public interface IOlxScraper
    {
        public Task TryParseOlx(SearchQuery searchQuery);
    }
}
