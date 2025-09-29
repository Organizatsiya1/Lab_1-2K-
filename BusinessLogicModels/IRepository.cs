using System.Collections.Generic;

namespace BusinessLogicModels
{
    public interface IRepository<T> where T:IDomainObject
    {
        void Create(T obj);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Update(T obj);
        void Delete(T obj);
    }
}
