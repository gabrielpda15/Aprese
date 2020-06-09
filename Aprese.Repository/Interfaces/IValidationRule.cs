using Aprese.DependencyInjection;
using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Repository.Interfaces
{
    [InjectableRule]
    public interface IValidationRule<TEntity> where TEntity : class, IEntity
    {
        Task<bool> OnCreateAsync(TEntity model, IDictionary<string, string> messages, CancellationToken ct = default);
        Task<bool> OnEditAsync(TEntity model, IDictionary<string, string> messages, CancellationToken ct = default);
        Task<bool> OnDeleteAsync(TEntity model, IDictionary<string, string> messages, CancellationToken ct = default);
        bool OnNew(TEntity model, IUserContext userContext);
    }
}
