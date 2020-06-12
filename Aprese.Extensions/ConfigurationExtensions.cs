using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T GetObject<T>(this IConfiguration configuration, string key = null)
        {
            return configuration.GetSection(key ?? typeof(T).Name).Get<T>();
        }
    }
}
