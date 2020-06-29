using Aprese.Extensions;
using Aprese.Models;
using Aprese.Repository;
using Aprese.Repository.DefaultImpl;
using Aprese.Repository.Interfaces;
using Aprese.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.WebAPI.Controllers
{
    public class TestController : ApreseController
    {
        public TestController(IServiceProvider provider) : base(provider)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] IRepository<TestEntity> testRepo, CancellationToken ct)        
        {
            var entity = await testRepo.GetNew(UserContext, ct);

            entity.Description = "Tesssst";

            await testRepo.CreateAsync(entity, UserContext, ct);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("Password/{password}")]
        public async Task<IActionResult> GetPasswordAsync([FromRoute] string password, CancellationToken ct)
        {
            return await Task.FromResult(Ok(Provider.GetRequiredService<Cryptography>().GenerateHash(password)));
        }
    }
}
