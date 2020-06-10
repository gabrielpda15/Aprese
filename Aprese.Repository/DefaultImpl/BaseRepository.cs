using Aprese.Models.Base;
using Aprese.Repository.Events;
using Aprese.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Repository.DefaultImpl
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApreseContext Context { get; }

        protected DbSet<TEntity> Entities { get; }

        protected IServiceProvider Provider { get; }

        public BaseRepository(ApreseContext context, IServiceProvider provider)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
            Provider = provider;
        }

        public virtual async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<IQueryable<TEntity>, IQueryable<TEntity>>> query, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, CancellationToken ct = default)
        {
            return await Task.Run(async () =>
            {
                var result = query?.Compile()?.Invoke(Entities);

                if (result == null) return await Entities.ToArrayAsync();

                if (orderBy != null) result = orderBy(result);

                return await result.ToArrayAsync(ct);
            }, ct);            
        }

        public virtual async Task<TEntity> QueryByIdAsync(int id, CancellationToken ct = default)
        {
            return await Entities.FindAsync(new[] { id }, ct);
        }

        public virtual async Task<TResult> QueryScalarAsync<TResult>(Expression<Func<IQueryable<TEntity>, TResult>> query, CancellationToken ct = default)
        {
            return await Task.Run(() =>
            {
                var result = query.Compile().Invoke(Entities);

                return result;
            }, ct);
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity, IUserContext userContext, CancellationToken ct = default)
        {
            var events = Provider.GetServices<IEvent<CreateAction<TEntity>>>().OrderBy(x => x.Order);

            foreach (var @event in events)
            {
                await @event.HandleAsync(new CreateAction<TEntity>() { Model = entity }, userContext, ct);
            }

            var rules = Provider.GetServices<IValidationRule<TEntity>>();

            foreach (var rule in rules)
            {
                var messages = new Dictionary<string, string>();
                var result = await rule.OnCreateAsync(entity, messages, ct);
                if (!result) throw new InvalidModelException(messages, entity);
            }

            Entities.Add(entity);

            await Context.SaveChangesAsync(ct);

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
