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

        public virtual async Task<TEntity> GetNew(IUserContext userContext, CancellationToken ct = default)
        {
            var rules = Provider.GetServices<IValidationRule<TEntity>>();
            
            var entity = Activator.CreateInstance<TEntity>();

            foreach (var rule in rules)
            {
                if (!await rule.OnNew(entity, userContext))
                {
                    throw new InvalidModelException(null, entity);
                }
            }

            return entity;
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

        public virtual async Task<TResult> QueryScalarAsync<TResult>(Expression<Func<IQueryable<TEntity>, Task<TResult>>> query, CancellationToken ct = default)
        {
            return await Task.Run(async () =>
            {
                var result = await query.Compile().Invoke(Entities);

                return result;
            }, ct);
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity, IUserContext userContext, CancellationToken ct = default)
        {
            var globalEvents = Provider.GetServices<IEvent<CreateAction<IEntity>>>().OrderBy(x => x.Order);
            var events = Provider.GetServices<IEvent<CreateAction<TEntity>>>().OrderBy(x => x.Order);

            foreach (var @event in globalEvents)
            {
                await @event.HandleAsync(new CreateAction<IEntity>() { Model = (IEntity)entity }, userContext, ct);
            }

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

        public async Task<IEnumerable<TEntity>> CreateManyAsync(IEnumerable<TEntity> entities, IUserContext userContext, CancellationToken ct = default)
        {
            var globalEvents = Provider.GetServices<IEvent<CreateManyAction<IEntity>>>().OrderBy(x => x.Order);
            var events = Provider.GetServices<IEvent<CreateManyAction<TEntity>>>().OrderBy(x => x.Order);

            foreach (var @event in globalEvents)
            {
                await @event.HandleAsync(new CreateManyAction<IEntity>() { Models = (IEnumerable<IEntity>)entities }, userContext, ct);
            }

            foreach (var @event in events)
            {
                await @event.HandleAsync(new CreateManyAction<TEntity>() { Models = entities }, userContext, ct);
            }

            var rules = Provider.GetServices<IValidationRule<TEntity>>();

            foreach (var rule in rules)
            {
                foreach (var entity in entities)
                {
                    var messages = new Dictionary<string, string>();
                    var result = await rule.OnCreateAsync(entity, messages, ct);
                    if (!result) throw new InvalidModelException(messages, entity);
                }
            }

            Entities.AddRange(entities);

            await Context.SaveChangesAsync(ct);

            return entities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, IUserContext userContext, CancellationToken ct = default)
        {
            var globalEvents = Provider.GetServices<IEvent<UpdateAction<IEntity>>>().OrderBy(x => x.Order);
            var events = Provider.GetServices<IEvent<UpdateAction<TEntity>>>().OrderBy(x => x.Order);

            foreach (var @event in globalEvents)
            {
                await @event.HandleAsync(new UpdateAction<IEntity>() { Model = (IEntity)entity }, userContext, ct);
            }

            foreach (var @event in events)
            {
                await @event.HandleAsync(new UpdateAction<TEntity>() { Model = entity }, userContext, ct);
            }

            var rules = Provider.GetServices<IValidationRule<TEntity>>();

            foreach (var rule in rules)
            {
                var messages = new Dictionary<string, string>();
                var result = await rule.OnEditAsync(entity, messages, ct);
                if (!result) throw new InvalidModelException(messages, entity);
            }

            Entities.Update(entity);

            await Context.SaveChangesAsync(ct);

            return entity;
        }

        public async Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities, IUserContext userContext, CancellationToken ct = default)
        {
            var globalEvents = Provider.GetServices<IEvent<UpdateManyAction<IEntity>>>().OrderBy(x => x.Order);
            var events = Provider.GetServices<IEvent<UpdateManyAction<TEntity>>>().OrderBy(x => x.Order);

            foreach (var @event in globalEvents)
            {
                await @event.HandleAsync(new UpdateManyAction<IEntity>() { Models = (IEnumerable<IEntity>)entities }, userContext, ct);
            }

            foreach (var @event in events)
            {
                await @event.HandleAsync(new UpdateManyAction<TEntity>() { Models = entities }, userContext, ct);
            }

            var rules = Provider.GetServices<IValidationRule<TEntity>>();

            foreach (var rule in rules)
            {
                foreach (var entity in entities)
                {
                    var messages = new Dictionary<string, string>();
                    var result = await rule.OnEditAsync(entity, messages, ct);
                    if (!result) throw new InvalidModelException(messages, entity);
                }
            }

            Entities.UpdateRange(entities);

            await Context.SaveChangesAsync(ct);

            return entities;
        }

        public async Task DeleteAsync(TEntity entity, IUserContext userContext, CancellationToken ct = default)
        {
            var globalEvents = Provider.GetServices<IEvent<DeleteAction<IEntity>>>().OrderBy(x => x.Order);
            var events = Provider.GetServices<IEvent<DeleteAction<TEntity>>>().OrderBy(x => x.Order);

            foreach (var @event in globalEvents)
            {
                await @event.HandleAsync(new DeleteAction<IEntity>() { Model = (IEntity)entity }, userContext, ct);
            }

            foreach (var @event in events)
            {
                await @event.HandleAsync(new DeleteAction<TEntity>() { Model = entity }, userContext, ct);
            }

            var rules = Provider.GetServices<IValidationRule<TEntity>>();

            foreach (var rule in rules)
            {
                var messages = new Dictionary<string, string>();
                var result = await rule.OnDeleteAsync(entity, messages, ct);
                if (!result) throw new InvalidModelException(messages, entity);
            }

            Entities.Remove(entity);

            await Context.SaveChangesAsync(ct);
        }

        public async Task DeleteManyAsync(IEnumerable<TEntity> entities, IUserContext userContext, CancellationToken ct = default)
        {
            var globalEvents = Provider.GetServices<IEvent<DeleteManyAction<IEntity>>>().OrderBy(x => x.Order);
            var events = Provider.GetServices<IEvent<DeleteManyAction<TEntity>>>().OrderBy(x => x.Order);

            foreach (var @event in globalEvents)
            {
                await @event.HandleAsync(new DeleteManyAction<IEntity>() { Models = (IEnumerable<IEntity>)entities }, userContext, ct);
            }

            foreach (var @event in events)
            {
                await @event.HandleAsync(new DeleteManyAction<TEntity>() { Models = entities }, userContext, ct);
            }

            var rules = Provider.GetServices<IValidationRule<TEntity>>();

            foreach (var rule in rules)
            {
                foreach (var entity in entities)
                {
                    var messages = new Dictionary<string, string>();
                    var result = await rule.OnDeleteAsync(entity, messages, ct);
                    if (!result) throw new InvalidModelException(messages, entity);
                }
            }

            Entities.RemoveRange(entities);

            await Context.SaveChangesAsync(ct);
        }
    }
}
