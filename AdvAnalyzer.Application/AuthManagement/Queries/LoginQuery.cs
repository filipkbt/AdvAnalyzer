using AdvAnalyzer.Common.Types;

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
