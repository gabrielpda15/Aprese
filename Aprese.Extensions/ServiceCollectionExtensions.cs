using Aprese.DependencyInjection;
using Aprese.Models;
using Aprese.Models.Security;
using Aprese.Repository;
using Aprese.Repository.DefaultImpl;
using Aprese.Repository.DefaultImpl.Security;
using Aprese.Repository.Events;
using Aprese.Repository.Interfaces;
using Aprese.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public static IServiceCollection AddApreseSecurity<TContext>(this IServiceCollection services, 
            IConfiguration configuration) where TContext : DbContext
        {
            services.AddIdentity<Identity, Role>()
                .AddEntityFrameworkStores<TContext>()
                .AddDefaultTokenProviders();

            services.AddSingleton<Security.Interfaces.IAuthenticationService, JwtIdentityAuthenticationService>();
            services.AddSingleton<Security.Interfaces.IAuthorizationService, ApreseAuthorizationService>();

            var tokenConfig = configuration.GetObject<TokenConfiguration>();
            services.AddSingleton(tokenConfig);

            var signingConfig = new SigningConfiguration();
            services.AddSingleton(signingConfig);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters.IssuerSigningKey = signingConfig.Key;
                opt.TokenValidationParameters.ValidAudience = tokenConfig.ValidAudience;
                opt.TokenValidationParameters.ValidIssuer = tokenConfig.ValidIssuer;
                opt.TokenValidationParameters.ValidateIssuerSigningKey = tokenConfig.ValidateIssuerSigningKey;
                opt.TokenValidationParameters.ValidateLifetime = tokenConfig.ValidateLifetime;
                opt.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy(TokenConfiguration.Policy, new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

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
