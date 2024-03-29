﻿using Aprese.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aprese.Repository.DefaultImpl.Security
{
    public class UserContextLoader : IUserContextLoader
    {
        private IHttpContextAccessor ContextAccessor { get; }

        public UserContextLoader(IHttpContextAccessor contextAccessor)
        {
            ContextAccessor = contextAccessor;
        }

        public void LoadData(IUserContext userContext)
        {
            try
            {
                var httpContext = ContextAccessor?.HttpContext;
                if (httpContext == null) return;

                userContext.Principal = httpContext.User;

                if (httpContext.Request != null)
                {
                    userContext.Ip = httpContext.Connection.RemoteIpAddress.ToString();
                    userContext.HostName = httpContext.Connection.RemoteIpAddress.ToString();
                    userContext.Claims = httpContext.User.Claims;
                    userContext.Data = userContext.Claims.Where(x => x.Type.ToLower() == "data").SingleOrDefault().Value;
                }
            }
            catch { }
        }
    }
}
