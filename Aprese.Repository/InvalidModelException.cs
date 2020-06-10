using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Repository
{
    public class InvalidModelException : Exception
    {
        public IDictionary<string, string> Messages { get; }

        public object Entity { get; }

        public InvalidModelException(IDictionary<string, string> messages, object entity) : base("Entidade não passou pela validação!") 
        {
            Messages = messages;
            Entity = entity;
        } 
    }
}
