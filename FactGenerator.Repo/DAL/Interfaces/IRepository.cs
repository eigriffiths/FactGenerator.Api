using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FactGenerator.Repo.DAL.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void Update(T entity);
        T Get(int id);
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        void SaveChanges();
    }
}
