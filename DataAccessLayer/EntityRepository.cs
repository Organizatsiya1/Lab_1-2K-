using Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly AdventureGuildContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityRepository(AdventureGuildContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> ReadAll()
        {
            // ToList() возвращает полную коллекцию
            return _dbSet.ToList();
        }

        public T ReadById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
