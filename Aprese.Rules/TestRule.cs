using Aprese.Models;
using Aprese.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Rules
{
    public class TestRule : IValidationRule<TestEntity>
    {
        public async Task<bool> OnCreateAsync(TestEntity model, IDictionary<string, string> messages, CancellationToken ct = default)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> OnDeleteAsync(TestEntity model, IDictionary<string, string> messages, CancellationToken ct = default)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> OnEditAsync(TestEntity model, IDictionary<string, string> messages, CancellationToken ct = default)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> OnNew(TestEntity model, IUserContext userContext)
        {
            model.Description = "[INITIAL VALUE]";

            return await Task.FromResult(true);
        }
    }
}
