using Aprese.Models.Base;
using Aprese.Repository.Events;
using Aprese.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Events
{
    public class AnyUpdateEvent : IEvent<UpdateAction<IEntity>>, IEvent<UpdateManyAction<IEntity>>
    {
        public uint Order => 0;

        public async Task HandleAsync(UpdateAction<IEntity> eventArg, IUserContext userContext, CancellationToken ct = default)
        {
            eventArg.Model.EditionDate = DateTime.Now;
            eventArg.Model.EditionUser = userContext?.Principal?.Identity?.Name;
            eventArg.Model.EditionIp = userContext?.Ip;

            await Task.FromResult(0);
        }

        public async Task HandleAsync(UpdateManyAction<IEntity> eventArg, IUserContext userContext, CancellationToken ct = default)
        {
            foreach (var entity in eventArg.Models)
            {
                entity.EditionDate = DateTime.Now;
                entity.EditionUser = userContext?.Principal?.Identity?.Name;
                entity.EditionIp = userContext?.Ip;
            }

            await Task.FromResult(0);
        }
    }
}
