using System;

namespace AdvAnalyzer.WebApi.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Url { get; set; }
        public string ImgUrl { get; set; }
        public string Location { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsSeen { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SearchQueryId { get; set; }
        public SearchQuery SearchQuery { get; set; }
    }
}
