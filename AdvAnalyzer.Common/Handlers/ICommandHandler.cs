using AdvAnalyzer.Common.Types;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace AdvAnalyzer.Common.Handlers
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task<Result> HandleAsync(T command);
    }
}
