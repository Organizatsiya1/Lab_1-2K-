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
