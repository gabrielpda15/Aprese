using Aprese.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Extensions
{
    public class CrudController<TEntity> : ApreseController where TEntity : class
    {
        protected IRepository<TEntity> Repository { get; }

        public CrudController(IServiceProvider provider) : base(provider)
        {
            Repository = provider.GetRequiredService<IRepository<TEntity>>();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> GetAsync(CancellationToken ct)
        {
            return Ok(await Repository.QueryAsync(q => q, null, ct));
        }
    }
}
