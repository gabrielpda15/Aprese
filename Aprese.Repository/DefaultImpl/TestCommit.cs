using Aprese.Models;
using Aprese.Models.Base;
using Aprese.Repository.Events;
using Aprese.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprese.Repository.DefaultImpl
{
    public class TestCommit
    {
        public IServiceProvider Provider { get; }

        public TestCommit(IServiceProvider provider)
        {
            Provider = provider;
        }

        public async Task CommitAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApreseContext>();
            optionsBuilder.UseMySql("Server=localhost;Database=Aprese;Uid=dev;Pwd=102030;", o =>
            {
                o.ServerVersion(new Version(8, 0, 0), ServerType.MySql);
            });

            using (var context = new ApreseContext(optionsBuilder.Options))
            {
                var temp = new TestEntity() { Description = "Testiculo" };
                context.Set<TestEntity>().Add(temp);

                var entities = context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is IEntity && (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

                foreach (var e in entities)
                {
                    var type = typeof(IEvent<>).MakeGenericType(typeof(CreateAction<>).MakeGenericType(e.Entity.GetType()));

                    var services = Provider.GetServices(type);
                }
            }

            await Task.FromResult(0);
        }

    }
}
