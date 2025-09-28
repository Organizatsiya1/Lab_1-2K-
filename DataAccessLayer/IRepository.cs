using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicModel;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject, new()
    {
        void Create(T obj);
        IEnumerable<T> ReadAll();
        T ReadByID(int id);
        void Update(T obj);
        void Delete(T obj);
    }
}
