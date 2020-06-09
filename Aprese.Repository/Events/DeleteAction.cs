﻿using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Repository.Events
{
    public class DeleteAction<TEntity> where TEntity : class, IEntity
    {
        public TEntity Model { get; set; }
    }
}
