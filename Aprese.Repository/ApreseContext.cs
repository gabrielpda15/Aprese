using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Repository
{
    public class ApreseContext : DbContext
    {
        public ApreseContext(DbContextOptions<ApreseContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }
    }
}
