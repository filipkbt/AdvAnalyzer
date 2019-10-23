using AdvAnalyzer.Auth.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAnalyzer.Auth.Services
{
    public interface IJwtFactory
    {
        string GenerateJwt(User user);
    }
}
