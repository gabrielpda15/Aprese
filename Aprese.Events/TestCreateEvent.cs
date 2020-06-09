using Aprese.Models;
using Aprese.Repository.Events;
using Aprese.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Events
{
    public class TestCreateEvent : IEvent<CreateAction<TestEntity>>
    {
        public uint Order => 0;

        public async Task HandleAsync(CreateAction<TestEntity> eventArg, IUserContext userContext, CancellationToken ct = default)
        {
            eventArg.Model.Description += "  [CONFIRMED]";

            await Task.FromResult(0);
        }
    }
}
