using Dapper;
using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
{
    private readonly string ConnectionString;
    private readonly string TableName;

    public DapperRepository()
    {
        ConnectionString = ConfigurationManager.ConnectionStrings["AdventureGuildDB"]?.ConnectionString;
        if (string.IsNullOrEmpty(ConnectionString))
        {
            throw new InvalidOperationException("Connection string not found");
        }
        TableName = typeof(T).Name + "s";
    }

    /// <summary>
    /// Создает новую запись в базе данных
    /// </summary>
    /// <param name="entity">Объект сущности для создания</param>
    /// <returns>Созданная сущность</returns>
    public T Create(T entity)
    {
        var properties = typeof(T).GetProperties()
            .Where(p => p.Name != "Id" && p.CanRead)
            .ToArray();

        var columns = string.Join(", ", properties.Select(p => p.Name));
        var values = string.Join(", ", properties.Select(p =>
        {
            var value = p.GetValue(entity);
            if (value is Enum)
                return $"{Convert.ToInt32(value)}";
            else if (value is string)
                return $"N'{value}'";
            else
                return value?.ToString() ?? "NULL";
        }));


        string script = $"INSERT INTO {TableName} ({columns}) VALUES({values})";
        UseScript(script);
        return entity;
    }

    /// <summary>
    /// Читает все записи из базы данных
    /// </summary>
    /// <returns>Список всех записей</returns>
    public IEnumerable<T> ReadAll()
    {
        List<T> entities;
        using (IDbConnection db = new SqlConnection(ConnectionString))
        {
            entities = db.Query<T>("SELECT * FROM " + TableName).ToList();
        }
        return entities;
    }

    /// <summary>
    /// Удаляет запись из базы данных
    /// </summary>
    /// <param name="entity">Объект сущности для удаления</param>
    public void Delete(T entity)
    {
        string script = $"DELETE FROM {TableName} WHERE Id = {entity.Id}";
        UseScript(script);
    }

    /// <summary>
    /// Читает запись по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <returns></returns>
    public T ReadById(int id)
    {
        T entity;
        using (IDbConnection db = new SqlConnection(ConnectionString))
        {
            entity = db.Query<T>("SELECT * FROM " + TableName + " WHERE Id = " + id).FirstOrDefault();
        }
        return entity;
    }

    /// <summary>
    /// Обновляет запись в базе данных
    /// </summary>
    /// <param name="entity">Объект сущности для обновления</param>
    /// <returns>Обновлённая сущность</returns>
    public T Update(T entity)
    {
        var properties = typeof(T).GetProperties()
            .Where(p => p.Name != "Id" && p.CanRead)
            .ToArray();

        var setClause = string.Join(", ", properties.Select(p =>
        {
            var value = p.GetValue(entity);
            string formattedValue;

            if (value is Enum)
                formattedValue = Convert.ToInt32(value).ToString();
            else if (value is string)
                formattedValue = $"N'{value}'";
            else if (value == null)
                formattedValue = "NULL";
            else
                formattedValue = value.ToString();

            return $"{p.Name} = {formattedValue}";
        }));

        string script = $"UPDATE {TableName} SET {setClause} WHERE Id = {entity.Id}";
        UseScript(script);
        return entity;
    }

    /// <summary>
    /// Выполняет SQL скрипт
    /// </summary>
    /// <param name="script">SQL скрипт для выполнения</param>
    private void UseScript(string script)
    {
        if (!string.IsNullOrEmpty(script))
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(script);
            }
    }
}