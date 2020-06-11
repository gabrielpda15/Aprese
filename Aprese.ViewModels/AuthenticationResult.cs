using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.ViewModels
{
    public class AuthenticationResult
    {
        public bool Authenticated { get; set; }
        public string CreatedAt { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
    }
}
