using Aprese.DependencyInjection;
using Aprese.Repository.Events;
using Aprese.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventsAndRules(this IServiceCollection services)
        {
            return services.AddEvents().AddRules();
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
