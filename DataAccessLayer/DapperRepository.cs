using Dapper;
using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
{
    private readonly string ConnectionString;
    private readonly string Name;

    public DapperRepository(string connectionString)
    {
        ConnectionString = connectionString;
        
    }
    public void Delete(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        Delete(entity);
        
    }

    

    

    // Остальные методы остаются без изменений
    public T Create(T entity)
    {
        using (IDbConnection db = new SqlConnection(ConnectionString))
        {
            // Определяем свойства для вставки (исключая ID, если он автоинкрементный)
            var properties = typeof(T).GetProperties()
                .Where(p => p.Name != "ID" && p.CanWrite)
                .Select(p => p.Name);

            var columns = string.Join(", ", properties);
            var parameters = string.Join(", ", properties.Select(p => "@" + p));

            var query = $"INSERT INTO {Name} ({columns}) VALUES ({parameters}); SELECT CAST(SCOPE_IDENTITY() as int)";

            entity.Id = db.Query<int>(query, entity, commandType: CommandType.Text).First();
        }
        return entity;
    }

    public IEnumerable<T> ReadAll()
    {
        using (IDbConnection db = new SqlConnection(ConnectionString))
        {
            return db.Query<T>($"SELECT * FROM {Name}");
        }
    }

    public T ReadById(int id)
    {
        using (IDbConnection db = new SqlConnection(ConnectionString))
        {
            return db.QueryFirstOrDefault<T>($"SELECT * FROM {Name} WHERE ID = @Id", new { Id = id });
        }
    }

    public T Update(T entity)
    {
        using (IDbConnection db = new SqlConnection(ConnectionString))
        {
            // Динамическое создание UPDATE запроса на основе свойств
            var properties = typeof(T).GetProperties()
                .Where(p => p.Name != "ID" && p.CanWrite)
                .Select(p => p.Name);

            var setClause = string.Join(", ", properties.Select(p => $"{p} = @{p}"));

            var query = $"UPDATE {Name} SET {setClause} WHERE ID = @ID";
            db.Execute(query, entity);
        }
        return entity;
    }

    
}