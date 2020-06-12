using Aprese.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Extensions
{
    [ApiController]
    //[Authorize]
    public class ApreseController : ControllerBase
    {
        protected IUserContext UserContext { get; }

        protected IServiceProvider Provider { get; }

        public ApreseController(IServiceProvider provider)
        {
            UserContext = provider.GetRequiredService<IUserContext>();
            Provider = provider;
        }
    }
}
