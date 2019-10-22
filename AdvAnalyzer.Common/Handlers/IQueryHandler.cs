using AdvAnalyzer.Common.Types;
using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace AdvAnalyzer.Common.Handlers
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<Result<TResult>> HandleAsync(TQuery query);
    }
}
