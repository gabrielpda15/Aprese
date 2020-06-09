using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.DependencyInjection
{
    public class InjectableRuleAttribute : InjectableAttribute
    {
        public InjectableRuleAttribute() : base(Lifetime.Transient)
        {
        }
    }
}
