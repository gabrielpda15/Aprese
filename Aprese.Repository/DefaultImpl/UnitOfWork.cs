using Aprese.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprese.Repository.DefaultImpl
{
    public class UnitOfWork
    {
        private ApreseContext Context { get; }

        private IServiceProvider Provider { get; }

        public UnitOfWork(IServiceProvider provider, ApreseContext context)
        {
            Provider = provider;
            Context = context;
        }

        public async Task CommitAsync()
        {
            var entities = Context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is IEntity && (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));



            foreach (var entity in entities)
            {
                //entity.
            }
        }
    }
}
