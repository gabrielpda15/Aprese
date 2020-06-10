using Aprese.Models;
using Aprese.Repository;
using Aprese.Repository.DefaultImpl;
using Aprese.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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
        public async Task<IActionResult> GetAsync([FromServices] IServiceProvider provider, CancellationToken ct)
        
        {
            var temp = provider.GetService<IRepository<TestEntity>>();





            await temp.CreateAsync(new TestEntity() { Description = "Tesssst" }, null, ct);
            return Ok();
        }
    }
}
