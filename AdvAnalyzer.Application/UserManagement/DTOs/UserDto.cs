using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAnalyzer.Application.UserManagement.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
