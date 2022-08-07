using AdvAnalyzer.WebApi.Models;
using System.Collections.Generic;

namespace AdvAnalyzer.WebApi.Dtos
{
    public class OlxScraperResultDto
    {
        public List<Advertisement> Advertisements { get; set; }
        public Notification Notification { get; set; }
        public string SearchQueryName { get; set; }
        public int SearchQueryId { get; set; }
        public bool UpdateSearchQueryIsInitialized { get; set; }
    }
}
