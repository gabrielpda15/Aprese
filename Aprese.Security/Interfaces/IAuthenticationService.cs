using Aprese.Models.Security;
using Aprese.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aprese.Security.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> AuthenticateAsync(BaseResult<Identity> result);
    }
}
