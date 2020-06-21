using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static IDictionary<string, string> GetErrorDictionary(this DbUpdateException ex)
        {
            var result = new Dictionary<string, string>();

            for (Exception tempEx = ex; tempEx != null; tempEx = tempEx.InnerException)
            {
                if (result.ContainsKey(tempEx.Source)) result[tempEx.Source] += $"\n{tempEx.Message}";
                else result.Add(tempEx.Source, tempEx.Message);
            }

            return result;
        }
    }
}
