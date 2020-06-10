using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Repository.Events
{
    public class CreateManyAction<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Models { get; set; }
    }
}
