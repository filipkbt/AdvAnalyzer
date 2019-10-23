using AdvAnalyzer.Application.AuthManagement.Commands;
using AdvAnalyzer.Application.AuthManagement.Contracts;
using AdvAnalyzer.Application.AuthManagement.Queries;
using AdvAnalyzer.Auth.Entities;
using AdvAnalyzer.Domain.Entities;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvAnalyzer.Auth.Services
{
    public class AuthService : IAuthService
    {
        private UserManager<User> _userManager;
        private IJwtFactory _jwtFactory;

        public AuthService(UserManager<User> userManager, IJwtFactory jwtFactory)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
        }

        public async Task<Result> RegisterAsync(RegisterCommand command)
        {
            if (!command.Password.Equals(command.ConfirmPassword))
            {
                return Result.Failure("Passwords do not match");
            }

            var applicationUser = new ApplicationUser(Guid.NewGuid(), command.Email,
                command.PhoneNumber);

            var user = new User(applicationUser, command.Login);

            var result = await _userManager.CreateAsync(user, command.Password);

            return result.Succeeded ? Result.Ok() : Result.Failure("Account could not have been created");
        }

        public async Task<Result<string>> LoginAsync(LoginQuery query)
        {
            var user = await _userManager.FindByNameAsync(query.Login);

            if (user == null)
            {
                return Result.Failure<string>("User with given user name does not exist");
            }

            if (!await _userManager.CheckPasswordAsync(user, query.Password))
            {
                return Result.Failure<string>("Wrong credentials");
            }

            var jwt = _jwtFactory.GenerateJwt(user);

            return Result.Ok(jwt);
        }
    }
}
