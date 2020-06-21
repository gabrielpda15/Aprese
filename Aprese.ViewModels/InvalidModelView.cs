using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.ViewModels
{
    public class InvalidModelView
    {
        public Exception Exception { get; set; }
        public IDictionary<string, string> Messages { get; set; }
    }
}
