using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.DependencyInjection
{
    public enum Lifetime { Singleton, Scoped, Transient }

    public class InjectableAttribute : Attribute
    {
        public Lifetime Lifetime { get; }

        public InjectableAttribute(Lifetime lifetime)
        {
            Lifetime = lifetime;
        }
    }
}
