using Api.Samples.Data.EntityFramework.Mappings;
using Api.Samples.Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Samples.Data.EntityFramework
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            : base(ConfigurationManager.ConnectionStrings["app_connection_string"].ConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Seed();
        }

        private void Seed()
        {
            if (this.Todo.Any())
                return;

            for (int i = 1; i < 127; i++)
                this.Todo.Add(new Todo
                {
                    Timestamp = DateTime.Now.AddHours(-i),
                    Text = $"Todo {Guid.NewGuid().ToString().Split('-')[0]} #{i}",
                    Id = Guid.NewGuid()
                });

            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TodoMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Todo> Todo { get; set; }
    }
}
