using Aprese.Models;
using Aprese.Models.Security;
using Aprese.Models.Security.Relations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Repository
{
    public class ApreseContext : IdentityDbContext<Identity, Role, int, IdentityClaim, IdentityRole, IdentityLogin, RoleClaim, IdentityToken>
    {
        public ApreseContext(DbContextOptions<ApreseContext> options) : base(options) { }

        public DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Identity>().ToTable("SEC_Identity");
            builder.Entity<Role>().ToTable("SEC_Role");
            builder.Entity<IdentityClaim>().ToTable("SEC_IdentityClaim");
            builder.Entity<IdentityRole>().ToTable("SEC_IdentityRole");
            builder.Entity<IdentityLogin>().ToTable("SEC_IdentityLogin");
            builder.Entity<RoleClaim>().ToTable("SEC_RoleClaim");
            builder.Entity<IdentityToken>().ToTable("SEC_IdentityToken");
        }
    }
}
