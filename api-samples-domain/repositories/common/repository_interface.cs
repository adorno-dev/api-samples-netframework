using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Samples.Domain.Repositories.Common
{
    public interface IRepository<T> where T : class
    {
        IList<T> All();
        IList<T> Get(Expression<Func<T, bool>> predicate);

        void Add(T item);
        void Update(T item);
        void Update<K>(K key, T item) where K : class;
        void Delete(T item);
        void Delete<K>(K key) where K : class;
    }
}
