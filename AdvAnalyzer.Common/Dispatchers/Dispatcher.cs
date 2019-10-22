using AdvAnalyzer.Common.Handlers;
using AdvAnalyzer.Common.Types;
using Autofac;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvAnalyzer.Common.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private IComponentContext _context;
        public Dispatcher(IComponentContext context)
        {
            _context = context;
        }
        public async Task<Result> DispatchAsync(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>)
                .MakeGenericType(command.GetType());

            dynamic handler = _context.Resolve(handlerType);

            return await handler.HandleAsync((dynamic)command);
        }


        public async Task<Result<T>> DispatchAsync<T>(IQuery<T> query)
        {
            var handlerType = typeof(IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof(T));

            dynamic handler = _context.Resolve(handlerType);

            return await handler.HandleAsync((dynamic)query);
        }
    }
}
