using System.Threading.Tasks;
using AdvAnalyzer.Common.Dispatchers;
using AdvAnalyzer.Common.Types;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvAnalyzer.WebAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class BaseController : ControllerBase
        {
            protected IDispatcher _dispatcher;

            protected BaseController(IDispatcher dispatcher)
            {
                _dispatcher = dispatcher;
            }

            protected async Task<Result> CommandAsync(ICommand command)
            {
                return await _dispatcher.DispatchAsync(command);
            }

            protected async Task<Result<T>> QueryAsync<T>(IQuery<T> query)
            {
                return await _dispatcher.DispatchAsync(query);
            }
        }
}
