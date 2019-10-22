using AdvAnalyzer.Application.AuthManagement.Commands;
using AdvAnalyzer.Application.AuthManagement.Queries;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvAnalyzer.Application.AuthManagement.Contracts
{
    public interface IAuthService
    {
        Task<Result> RegisterAsync(RegisterCommand command);
        Task<Result<string>> LoginAsync(LoginQuery query);
    }
}
