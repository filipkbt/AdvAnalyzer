using System;
using System.Collections.Generic;

namespace AdvAnalyzer.WebApi.Models
{
    public class SearchQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int RefreshFrequencyInMinutes { get; set; }
        public bool SendEmailNotifications { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
