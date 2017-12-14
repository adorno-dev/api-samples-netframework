using Api.Samples.Domain.Models;
using Api.Samples.Domain.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Samples.Data.EntityFramework.Repositories
{
    public class TodoRepository : IRepository<Todo>
    {
        private AppDataContext context;

        public TodoRepository() => context = new AppDataContext();

        public IList<Todo> All() => context.Set<Todo>().ToList();

        public IList<Todo> Get(Expression<Func<Todo, bool>> predicate)
            => context.Set<Todo>().Where(predicate).ToList();

        public void Add(Todo item)
        {
            context.Set<Todo>().Add(item);
            context.SaveChanges();
        }

        public void Delete(Todo item)
        {
            context.Set<Todo>().Remove(item);
            context.SaveChanges();
        }

        public void Delete<K>(K key) where K : class
        {
            context.Set<Todo>().Remove(context.Set<Todo>().Find(key));
            context.SaveChanges();
        }

        public void Update(Todo item)
        {
            context.Entry<Todo>(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Update<K>(K key, Todo item) where K : class
            => this.Update(context.Set<Todo>().Find(key));
    }
}
