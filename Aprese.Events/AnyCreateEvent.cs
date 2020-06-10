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
    public class AnyCreateEvent : IEvent<CreateAction<IEntity>>, IEvent<CreateManyAction<IEntity>>
    {
        public uint Order => 0;

        public async Task HandleAsync(CreateAction<IEntity> eventArg, IUserContext userContext, CancellationToken ct = default)
        {
            eventArg.Model.CreationDate = DateTime.Now;
            eventArg.Model.EditionDate = DateTime.Now;
            eventArg.Model.CreationUser = userContext.Principal.Identity.Name;
            eventArg.Model.EditionUser = userContext.Principal.Identity.Name;
            eventArg.Model.CreationIp = userContext.Ip;
            eventArg.Model.EditionIp = userContext.Ip;

            await Task.FromResult(0);
        }

        public async Task HandleAsync(CreateManyAction<IEntity> eventArg, IUserContext userContext, CancellationToken ct = default)
        {
            foreach (var entity in eventArg.Models)
            {
                entity.CreationDate = DateTime.Now;
                entity.EditionDate = DateTime.Now;
                entity.CreationUser = userContext.Principal.Identity.Name;
                entity.EditionUser = userContext.Principal.Identity.Name;
                entity.CreationIp = userContext.Ip;
                entity.EditionIp = userContext.Ip;
            }

            await Task.FromResult(0);
        }
    }
}
