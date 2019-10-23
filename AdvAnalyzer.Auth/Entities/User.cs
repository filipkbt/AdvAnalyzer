using AdvAnalyzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace AdvAnalyzer.Auth.Entities
{
    public class User : IdentityUser
    {
        public User(ApplicationUser owner, string userName)
        {
            ApplicationUser = ApplicationUser;
            UserName = userName;
        }

        private User()
        {
        }

        public ApplicationUser ApplicationUser { get; private set; }
    }
}
