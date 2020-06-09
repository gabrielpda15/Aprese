using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.DependencyInjection
{
    public class InjectableEventAttribute : InjectableAttribute
    {
        public InjectableEventAttribute() : base(Lifetime.Transient)
        {
        }
    }
}
