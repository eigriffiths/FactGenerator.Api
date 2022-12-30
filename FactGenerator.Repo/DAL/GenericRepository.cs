using FactGenerator.Repo.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FactGenerator.Repo.DAL
{
    public class GenericRepository<T>
        : IRepository<T> where T : class, IEntity
    {
        public readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual T Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

            return entity;
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> All()
        {
            return _context.Set<T>()
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                .AsQueryable()
                .Where(predicate);
        }
        public T Get(int id)
        {
            return _context.Set<T>()
                .FirstOrDefault(x => x.Id == id);
        }

        public void Delete(T entity)
        {
            _context.Attach(entity);
            _context.Remove(entity);

            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
