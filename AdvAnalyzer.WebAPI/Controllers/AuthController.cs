using System.Linq;
using System.Threading.Tasks;
using AdvAnalyzer.Application.AuthManagement.Commands;
using AdvAnalyzer.Application.AuthManagement.DTOs;
using AdvAnalyzer.Application.AuthManagement.Queries;
using AdvAnalyzer.Application.UserManagement.DTOs;
using AdvAnalyzer.Application.UserManagement.Queries;
using AdvAnalyzer.Auth;
using AdvAnalyzer.Common.Dispatchers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvAnalyzer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        public AuthController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserForCreationDto model)
        {
            var command = new RegisterCommand(model.Email, model.PhoneNumber,
                model.Login, model.Password, model.ConfirmPassword);

            var result = await _dispatcher.DispatchAsync(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return await LoginAsync(new LoginCredentials() { Password = model.Password, Login = model.Login });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCredentials model)
        {
            var query = new LoginQuery(model.Login, model.Password);

            var result = await _dispatcher.DispatchAsync(query);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == Constants.UserId)?.Value;

            var result = await _dispatcher.DispatchAsync(new GetUserQuery(userId));

            return result.IsSuccess ? (IActionResult)Ok(result.Value) : NotFound(result.Error);
        }
    }
}
