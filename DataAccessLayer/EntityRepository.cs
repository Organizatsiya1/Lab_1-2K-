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

        /// <summary>
        /// Создает новую запись в базе данных
        /// </summary>
        /// <param name="entity">Объект сущности для создания</param>
        /// <returns>Созданная сущность</returns>
        public T Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Читает все записи из базы данных
        /// </summary>
        /// <returns>Список всех записей</returns>
        public IEnumerable<T> ReadAll()
        {
            // ToList() возвращает полную коллекцию
            return _dbSet.ToList();
        }

        /// <summary>
        /// Читает запись по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>Найдённая запись или null</returns>
        public T ReadById(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Обновляет существующую запись в базе данных
        /// </summary>
        /// <param name="entity">Объект сущности для обновления</param>
        /// <returns>Обновлённая сущность</returns>
        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Удаляет запись из базы данных
        /// </summary>
        /// <param name="entity">Объект сущности для удаления</param>
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
