using AdvAnalyzer.WebApi.Models;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Repositories
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
