using Api.Samples.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Samples.Data.EntityFramework.Mappings
{
    public class TodoMap : EntityTypeConfiguration<Todo>
    {
        public TodoMap()
        {
            this.ToTable("todo");

            this.HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("id");

            this.Property(x => x.Timestamp)
                .HasColumnName("timestamp");

            this.Property(x => x.Text)
                .HasColumnName("text");

            this.Property(x => x.Done)
                .HasColumnName("done");
        }
    }
}
