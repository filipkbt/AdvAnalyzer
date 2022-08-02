using System;

namespace AdvAnalyzer.WebApi.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsSeen { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SearchQueryId { get; set; }
        public SearchQuery SearchQuery { get;set; }
    }
}
