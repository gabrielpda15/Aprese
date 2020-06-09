using Aprese.Models.Base;
using Aprese.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Repository.DefaultImpl
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected TContext Context { get; }

        protected DbSet<TEntity> Entities { get; }

        public BaseRepository(TContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<IQueryable<TEntity>, IQueryable<TEntity>>> query, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, CancellationToken ct = default)
        {
            return await Task.Run(async () =>
            {
                var result = query?.Compile()?.Invoke(Entities);

                if (result == null) return await Entities.ToArrayAsync();

                if (orderBy != null) result = orderBy(result);

                return await result.ToArrayAsync(ct);
            }, ct);            
        }

        public async Task<TEntity> QueryByIdAsync(int id, CancellationToken ct = default)
        {
            return await Entities.FindAsync(new[] { id }, ct);
        }

        public async Task<TResult> QueryScalarAsync<TResult>(Expression<Func<IQueryable<TEntity>, TResult>> query, CancellationToken ct = default)
        {
            return await Task.Run(() =>
            {
                var result = query.Compile().Invoke(Entities);

                return result;
            }, ct);
        }

        public async Task<TEntity> CreateAsync(TEntity entity, IUserContext userContext, CancellationToken ct = default)
        {
            Entities.Add(entity);

            return entity;
        }

        public Task<IEnumerable<TEntity>> CreateManyAsync(IEnumerable<TEntity> entities, IUserContext userContext, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity, IUserContext userContext, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities, IUserContext userContext, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity, IUserContext userContext, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(IEnumerable<TEntity> entities, IUserContext userContext, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
