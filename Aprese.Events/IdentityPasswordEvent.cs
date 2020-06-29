using Aprese.Models.Security;
using Aprese.Repository.Events;
using Aprese.Repository.Interfaces;
using Aprese.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Events
{
    public class IdentityPasswordEvent : IEvent<CreateAction<Identity>>, IEvent<UpdateAction<Identity>>
    {
        public uint Order => 0;
        private Cryptography Cryptography { get; }

        public IdentityPasswordEvent(Cryptography cryptography)
        {
            Cryptography = cryptography;
        }

        public Task HandleAsync(UpdateAction<Identity> eventArg, IUserContext userContext, CancellationToken ct = default)
        {
            eventArg.Model.PasswordHash = Cryptography.GenerateHash(eventArg.Model.Password);
            eventArg.Model.NormalizedEmail = eventArg.Model.Email.ToLower();
            eventArg.Model.NormalizedUserName = eventArg.Model.UserName.ToLower();
            return Task.CompletedTask;
        }

        public Task HandleAsync(CreateAction<Identity> eventArg, IUserContext userContext, CancellationToken ct = default)
        {
            eventArg.Model.PasswordHash = Cryptography.GenerateHash(eventArg.Model.Password);
            eventArg.Model.NormalizedEmail = eventArg.Model.Email.ToLower();
            eventArg.Model.NormalizedUserName = eventArg.Model.UserName.ToLower();
            return Task.CompletedTask;
        }
    }
}
