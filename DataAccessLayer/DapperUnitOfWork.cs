using Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public IRepository<Fighter> Fighters { get; }
        public IRepository<Mage> Mages { get; }

        public DapperUnitOfWork()
        {
            Fighters = new DapperRepository<Fighter>();
            Mages = new DapperRepository<Mage>();

            var connectionString = ConfigurationManager.ConnectionStrings["AdventureGuildDB"]?.ConnectionString;

            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// Сохраняет все изменения, внесенные в контекст базы данных
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            //finally
            //{
            //    _transaction?.Dispose();
            //    _transaction = null;
            //}
        }

        /// <summary>
        /// Освобождает все ресурсы, используемые контекстом базы данных
        /// </summary>
        public void Dispose()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();

            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
