using Aprese.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Repository.Interfaces
{
    [InjectableEvent]
    public interface IEvent<TEvent> where TEvent : class
    {
        uint Order { get; }

        Task HandleAsync(TEvent eventArg, IUserContext userContext, CancellationToken ct = default);
    }
}
