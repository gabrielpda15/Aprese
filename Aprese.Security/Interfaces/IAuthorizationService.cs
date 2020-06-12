using Aprese.Models.Security;
using Aprese.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Security.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<BaseResult<Identity>> AuthorizeAsync(LoginUser loginUser, CancellationToken ct = default);
    }
}
