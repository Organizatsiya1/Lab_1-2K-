using Models;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject
    {
        T Create(T obj);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        T Update(T obj);
        void Delete(T obj);
    }
}
