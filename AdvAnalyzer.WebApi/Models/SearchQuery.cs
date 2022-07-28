using System.Collections.Generic;

namespace AdvAnalyzer.WebApi.Models
{
    public class SearchQuery
    {
        public int SearchQueryId { get; set; }
        public string Name { get; set; }
        public int RefreshFrequencyInMinutes { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
