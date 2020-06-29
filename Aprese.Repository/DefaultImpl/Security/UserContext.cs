using Aprese.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Aprese.Repository.DefaultImpl.Security
{
    public class UserContext : IUserContext
    {
        public IPrincipal Principal { get; set; }
        public string Ip { get; set; }
        public string HostName { get; set; }
        public object Data { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
