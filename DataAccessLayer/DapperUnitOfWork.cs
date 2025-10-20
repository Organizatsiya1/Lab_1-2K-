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

        /// <summary>
        /// Сохраняет все изменения, внесенные в контекст базы данных
        /// </summary>
        public void SaveChanges()
        {
            
        }

        /// <summary>
        /// Освобождает все ресурсы, используемые контекстом базы данных
        /// </summary>
        public void Dispose()
        {
            
        }
    }
}
