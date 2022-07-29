using AdvAnalyzer.WebApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvAnalyzer.WebApi.Dtos
{
    public class SearchQueryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int RefreshFrequencyInMinutes { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public bool SendEmailNotifications { get; set; }

        public int Results { get; set; }
        public int NewResults { get; set; }
    }
}
