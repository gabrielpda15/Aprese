using Aprese.Repository.DefaultImpl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public async Task<IActionResult> GetAsync([FromServices] TestCommit testCommit, CancellationToken ct)
        {
            await testCommit.CommitAsync();
            return Ok();
        }
    }
}
