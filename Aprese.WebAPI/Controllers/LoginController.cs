using Aprese.Models.Security;
using Aprese.Security.Interfaces;
using Aprese.ViewModels;
using Microsoft.AspNetCore.Http;
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
    public sealed class LoginController : ControllerBase
    {
        private IAuthenticationService AuthenticationService { get; }
        private IAuthorizationService AuthorizationService { get; }

        public LoginController(IAuthenticationService authenticationService,
                               IAuthorizationService authorizationService)
        {
            AuthenticationService = authenticationService;
            AuthorizationService = authorizationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthenticationResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenticationResult), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PostLoginAsync([FromBody] LoginUser loginUser, CancellationToken ct)
        {
            var authResult = await AuthorizationService.AuthorizeAsync(loginUser, ct);
            var finalResult = await AuthenticationService.AuthenticateAsync(authResult);
            if (finalResult.Authenticated)
                return Ok(finalResult);
            else
                return Unauthorized(finalResult);
        }
    }
}
