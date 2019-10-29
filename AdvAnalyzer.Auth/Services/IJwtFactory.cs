using AdvAnalyzer.Auth.Entities;

namespace AdvAnalyzer.Auth.Services
{
    public interface IJwtFactory
    {
        string GenerateJwt(User user);
    }
}
