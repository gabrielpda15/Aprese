using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Aprese.Repository.Interfaces
{
    public interface IUserContext
    {
        IPrincipal Principal { get; set; }
        string Ip { get; set; }
        string HostName { get; set; }
        object Data { get; set; }
        IEnumerable<Claim> Claims { get; set; }
    }
}
