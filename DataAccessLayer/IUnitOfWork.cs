using Models;

namespace DataAccessLayer
{
    public interface IUnitOfWork
    {
        IRepository<Fighter> Fighters { get; }
        IRepository<Mage> Mages { get; }

        /// <summary>
        /// Сохраняет все изменения, внесенные в контекст базы данных
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Освобождает все ресурсы, используемые контекстом базы данных
        /// </summary>
        void Dispose();
    }
}
