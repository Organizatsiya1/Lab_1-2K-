using Models;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject
    {
        /// <summary>
        /// Создает новую запись в базе данных
        /// </summary>
        /// <param name="entity">Объект сущности для создания</param>
        /// <returns>Созданная сущность</returns>
        T Create(T obj);

        /// <summary>
        /// Читает все записи из базы данных
        /// </summary>
        /// <returns>Список всех записей</returns>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Читает запись по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>Найдённая запись или null</returns>
        T ReadById(int id);

        /// <summary>
        /// Обновляет существующую запись в базе данных
        /// </summary>
        /// <param name="entity">Объект сущности для обновления</param>
        /// <returns>Обновлённая сущность</returns>
        T Update(T obj);

        /// <summary>
        /// Удаляет запись из базы данных
        /// </summary>
        /// <param name="entity">Объект сущности для удаления</param>
        void Delete(T obj);
    }
}
