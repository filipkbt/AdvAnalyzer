using AdvAnalyzer.WebApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvAnalyzer.WebApi.Dtos
{
    public class SearchQueryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int RefreshFrequencyInMinutes { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
