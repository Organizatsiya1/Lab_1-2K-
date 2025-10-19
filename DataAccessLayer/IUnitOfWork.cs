using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public interface IUnitOfWork
    {
        IRepository<Fighter> Fighters { get; }
        IRepository<Mage> Mages { get; }
        void SaveChanges();
        void Dispose();
    }
}
