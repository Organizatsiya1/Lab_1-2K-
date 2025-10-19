using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EntityUnitOfWork : IUnitOfWork
    {
        private readonly AdventureGuildContext Context;
        

        public IRepository<Fighter> Fighters { get; }
        public IRepository<Mage> Mages { get; }

        public EntityUnitOfWork()
        {
            
            Context = new AdventureGuildContext();

            // Используем Entity Framework для операций
            Fighters = new EntityRepository<Fighter>(Context);
            Mages = new EntityRepository<Mage>(Context);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
