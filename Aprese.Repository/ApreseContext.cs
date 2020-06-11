using Aprese.Models;
using Aprese.Models.Base;
using Aprese.Models.Configuration;
using Aprese.Models.Location;
using Aprese.Models.Security;
using Aprese.Models.Security.Relations;
using Aprese.Models.System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.Repository
{
    public class ApreseContext : IdentityDbContext<Identity, Role, int, IdentityClaim, IdentityRole, IdentityLogin, RoleClaim, IdentityToken>
    {
        public ApreseContext(DbContextOptions<ApreseContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Status> Statuses { get; set; }

        // Entidade para testes de repositorio, não estara presente na versão final
        public DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<City>().HasOne(x => x.State).WithMany().OnDelete(DeleteBehavior.Cascade);




            // Sobrescrição das tables padrões do Entity Framework Identity
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
