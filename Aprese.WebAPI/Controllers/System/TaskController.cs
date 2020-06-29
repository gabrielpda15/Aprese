using Aprese.Extensions;
using Aprese.Models.System;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.WebAPI.Controllers.System
{
    public class TaskController : CrudController<Models.System.Task>
    {
        public TaskController(IServiceProvider provider) : base(provider)
        {
        }

        public async Task<IActionResult> GetGridAsync(CancellationToken ct)
        {
            var result = await Repository.QueryAsync(q => q.Where(x => x.Identity.UserName == ""), null, ct);

            return Ok();
        }
    }
}
