using Aprese.Extensions;
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
    [Route("api/[controller]")]
    public class TestController : ApreseController
    {
        public TestController(IServiceProvider provider) : base(provider)
        {
        }

        public async Task<IActionResult> GetAsync([FromServices] IRepository<TestEntity> testRepo, CancellationToken ct)        
        {
            var entity = await testRepo.GetNew(UserContext, ct);

            entity.Description = "Tesssst";

            await testRepo.CreateAsync(entity, UserContext, ct);

            return Ok();
        }
    }
}
