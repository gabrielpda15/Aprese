using Aprese.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Repository.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasOne(x => x.Status).WithMany().OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.Identity).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
