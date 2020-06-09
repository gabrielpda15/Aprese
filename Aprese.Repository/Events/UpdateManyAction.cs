using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Repository.Events
{
    public class UpdateManyAction<TEntity> where TEntity : class, IEntity
    {
        public IEnumerable<TEntity> Models { get; set; }
    }
}
