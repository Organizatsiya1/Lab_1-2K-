using Models;

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

        /// <summary>
        /// Сохраняет все изменения, внесенные в контекст базы данных
        /// </summary>
        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Освобождает все ресурсы, используемые контекстом базы данных
        /// </summary>
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
