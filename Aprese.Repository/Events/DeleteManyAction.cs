using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Repository.Events
{
    public class DeleteManyAction<TEntity> where TEntity : class, IEntity
    {
        public IEnumerable<TEntity> Models { get; set; }
    }
}
