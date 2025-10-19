using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        public IRepository<Fighter> Fighters { get; }
        public IRepository<Mage> Mages { get; }

        public DapperUnitOfWork()
        {
            Fighters = new DapperRepository<Fighter>();
            Mages = new DapperRepository<Mage>();
        }

        public void SaveChanges()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
