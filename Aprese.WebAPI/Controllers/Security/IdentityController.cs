using Aprese.Extensions;
using Aprese.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aprese.WebAPI.Controllers.Security
{
    public class IdentityController : CrudController<Identity>
    {
        public IdentityController(IServiceProvider provider) : base(provider)
        {
        }
    }
}
