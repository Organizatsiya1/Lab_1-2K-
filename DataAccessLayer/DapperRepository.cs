using BusinessLogicModels;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer
{
    // DapperRepository<T> - ТОЧНО как в задании п.5b.i
    public class DapperRepository<T>: IRepository<T> where T : class, IDomainObject
    {
        private readonly string connectionString;
        private readonly string tableName;

        public DapperRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(T item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                // Получаем все свойства кроме Id (для INSERT)
                var properties = typeof(T).GetProperties()
                    .Where(p => p.Name != "Id" && p.CanWrite)
                    .ToList();

                var columnNames = string.Join(", ", properties.Select(p => p.Name));
                var parameterNames = string.Join(", ", properties.Select(p => $"@{p.Name}"));

                var sql = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames}); SELECT CAST(SCOPE_IDENTITY() as int)";

                // Dapper автоматически маппит параметры по имени
                var newId = db.QuerySingle<int>(sql, item);
                item.Id = newId; // Устанавливаем сгенерированный ID
            }
        }

        public IEnumerable<T> ReadAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<T>($"SELECT * FROM {tableName}");
            }
        }

        public T ReadById(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.QueryFirstOrDefault<T>(
                    $"SELECT * FROM {tableName} WHERE Id = @Id",
                    new { Id = id });
            }
        }

        public void Update(T item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var properties = typeof(T).GetProperties()
                    .Where(p => p.Name != "Id" && p.CanWrite);

                var setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

                var sql = $"UPDATE {tableName} SET {setClause} WHERE Id = @Id";
                db.Execute(sql, item);
            }
        }

        public void Delete(T item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute($"DELETE FROM {tableName} WHERE Id = @Id", new { item.Id });
            }
        }
    }
}
