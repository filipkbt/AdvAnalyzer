using AdvAnalyzer.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAnalyzer.Application.AuthManagement.Queries
{
    public class LoginQuery : IQuery<string>
    {
        public LoginQuery(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public string Login { get; private set; }
        public string Password { get; private set; }
    }
}
