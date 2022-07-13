﻿using System.ComponentModel.DataAnnotations;

namespace AdvAnalyzer.WebApi.Dtos
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Email must be at least 3 characters")]
        public string Email { get; set; }
        [Required]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "You must provide password between 8 and 20 characters")]
        public string Password { get; set; }
    }
}
