using Aprese.Models.Base;
using Aprese.Repository;
using Aprese.Repository.Interfaces;
using Aprese.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Extensions
{
    public class CrudController<TEntity> : ApreseController where TEntity : class, IEntity
    {
        protected IRepository<TEntity> Repository { get; }

        public CrudController(IServiceProvider provider) : base(provider)
        {
            Repository = provider.GetRequiredService<IRepository<TEntity>>();
        }

        [HttpGet("GetNew")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> GetNewAsync(CancellationToken ct)
        {
            return Ok(await Repository.GetNew(UserContext, ct));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> GetAsync(CancellationToken ct)
        {
            return Ok(await Repository.QueryAsync(q => q, null, ct));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> GetByIdAsync([FromRoute] int id, CancellationToken ct)
        {
            return Ok(await Repository.QueryByIdAsync(id, ct));
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(InvalidModelView), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> PostAsync([FromBody] TEntity entity, CancellationToken ct)
        {
            try
            {
                var result = await Repository.CreateAsync(entity, UserContext, ct);
                return CreatedAtAction(nameof(GetByIdAsync), result.Id, result);
            }
            catch (InvalidModelException ex)
            {
                return BadRequest(new InvalidModelView { Exception = null, Messages = ex.Messages });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new InvalidModelView { Exception = ex, Messages = null });
            }
        }

        [HttpPost("Many")]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidModelView), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> PostManyAsync([FromBody] IEnumerable<TEntity> entities, CancellationToken ct)
        {
            try
            {
                var result = await Repository.CreateManyAsync(entities, UserContext, ct);
                return Ok(result);
            }
            catch (InvalidModelException ex)
            {
                return BadRequest(new InvalidModelView { Exception = null, Messages = ex.Messages });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new InvalidModelView { Exception = ex, Messages = null });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidModelView), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> PutAsync([FromBody] TEntity entity, CancellationToken ct)
        {
            try
            {
                var result = await Repository.UpdateAsync(entity, UserContext, ct);
                return Ok(result);
            }
            catch (InvalidModelException ex)
            {
                return BadRequest(new InvalidModelView { Exception = null, Messages = ex.Messages });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new InvalidModelView { Exception = ex, Messages = null });
            }
        }

        [HttpPut("Many")]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidModelView), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> PutManyAsync([FromBody] IEnumerable<TEntity> entities, CancellationToken ct)
        {
            try
            {
                var result = await Repository.UpdateManyAsync(entities, UserContext, ct);
                return Ok(result);
            }
            catch (InvalidModelException ex)
            {
                return BadRequest(new InvalidModelView { Exception = null, Messages = ex.Messages });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new InvalidModelView { Exception = ex, Messages = null });
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidModelView), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] int id, CancellationToken ct)
        {
            try
            {
                var entity = await Repository.QueryByIdAsync(id, ct);
                if (entity == null) return NotFound();
                await Repository.DeleteAsync(entity, UserContext, ct);
                return Ok();
            }
            catch (InvalidModelException ex)
            {
                return BadRequest(new InvalidModelView { Exception = null, Messages = ex.Messages });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new InvalidModelView { Exception = ex, Messages = null });
            }
        }

        [HttpDelete("Many/{ids}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidModelView), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> DeleteManyAsync([FromRoute] string ids, CancellationToken ct)
        {
            try
            {
                var nIds = ids.Split(',').Select(x => int.Parse(x));
                var entities = await Repository.QueryAsync(q => q.Where(x => nIds.Contains(x.Id)), null, ct);
                await Repository.DeleteManyAsync(entities, UserContext, ct);
                return Ok();
            }
            catch (InvalidModelException ex)
            {
                return BadRequest(new InvalidModelView { Exception = null, Messages = ex.Messages });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new InvalidModelView { Exception = ex, Messages = null });
            }
        }
    }
}
