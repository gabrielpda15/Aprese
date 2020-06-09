﻿using Aprese.Repository.Interfaces;
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
        public string IP { get; set; }
        public string HostName { get; set; }
        public string[] Languages { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string SelectedRole { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
        public IDictionary<string, object> Parametros { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
