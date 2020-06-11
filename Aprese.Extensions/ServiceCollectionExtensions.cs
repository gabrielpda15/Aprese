using Aprese.DependencyInjection;
using Aprese.Models;
using Aprese.Models.Security;
using Aprese.Repository;
using Aprese.Repository.DefaultImpl;
using Aprese.Repository.DefaultImpl.Security;
using Aprese.Repository.Events;
using Aprese.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Aprese.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventsAndRules(this IServiceCollection services)
        {
            return services.AddEvents().AddRules();
        }

        public static IServiceCollection AddApreseSecurity<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            services.AddIdentity<Identity, Role>()
                .AddEntityFrameworkStores<TContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            return services;
        }

        public static IServiceCollection AddUserContext(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IUserContextLoader, UserContextLoader>();
            services.AddScoped<IUserContext>(s => 
            {
                var userContext = new UserContext();
                s.GetRequiredService<IUserContextLoader>().LoadData(new UserContext());
                return userContext;
            });
            return services;
        }

        private static IServiceCollection AddEvents(this IServiceCollection services)
        {
            var types = WebHostBuilderExtensions.Assemblies.SelectMany(x => x.GetTypes())
                .Where(x => x.GetInterfaces().FirstOrDefault()?.GetCustomAttribute<InjectableEventAttribute>() != null);

            foreach (var type in types)
            {
                services.AddTransient(type.GetInterfaces().FirstOrDefault(), type);
            }

            return services;
        }

        private static IServiceCollection AddRules(this IServiceCollection services)
        {
            var types = WebHostBuilderExtensions.Assemblies.SelectMany(x => x.GetTypes())
                .Where(x => x.GetInterfaces().FirstOrDefault()?.GetCustomAttribute<InjectableRuleAttribute>() != null);

            foreach (var type in types)
            {
                services.AddTransient(type.GetInterfaces().FirstOrDefault(), type);
            }

            return services;
        }
    }
}
