using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetNew(IUserContext userContext, CancellationToken ct = default);
        Task<TEntity> QueryByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<IQueryable<TEntity>, IQueryable<TEntity>>> query, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, CancellationToken ct = default);
        Task<TResult> QueryScalarAsync<TResult>(Expression<Func<IQueryable<TEntity>, Task<TResult>>> query, CancellationToken ct = default);
        Task<TEntity> CreateAsync(TEntity entity, IUserContext userContext, CancellationToken ct = default);
        Task<IEnumerable<TEntity>> CreateManyAsync(IEnumerable<TEntity> entities, IUserContext userContext, CancellationToken ct = default);
        Task<TEntity> UpdateAsync(TEntity entity, IUserContext userContext, CancellationToken ct = default);
        Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities, IUserContext userContext, CancellationToken ct = default);
        Task DeleteAsync(TEntity entity, IUserContext userContext, CancellationToken ct = default);
        Task DeleteManyAsync(IEnumerable<TEntity> entities, IUserContext userContext, CancellationToken ct = default);
    }
}
