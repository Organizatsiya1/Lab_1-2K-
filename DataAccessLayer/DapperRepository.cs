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


    public T Create(T entity)
    {
        var properties = typeof(T).GetProperties()
            .Where(p => p.Name != "Id" && p.CanRead)
            .ToArray();

        var columns = string.Join(", ", properties.Select(p => p.Name));
        var values = string.Join(", ", properties.Select(p => $"'{p.GetValue(entity)}'"));

        string script = $"INSERT INTO {TableName} ({columns}) VALUES({values})";
        UseScript(script);
        return entity;
    }

    public IEnumerable<T> ReadAll()
    {
        List<T> entities;
        using (IDbConnection db = new SqlConnection(ConnectionString))
        {
            entities = db.Query<T>("SELECT * FROM " + TableName).ToList();
        }
        return entities;
    }

    public void Delete(T entity)
    {
        string script = $"DELETE FROM {TableName} WHERE Id = {entity.Id}";
        UseScript(script);
    }

    public T ReadById(int id)
    {
        T entity;
        using (IDbConnection db = new SqlConnection(ConnectionString))
        {
            entity = db.Query<T>("SELECT * FROM " + TableName + " WHERE Id = " + id).FirstOrDefault();
        }
        return entity;
    }

    public T Update(T entity)
    {
        var properties = typeof(T).GetProperties()
            .Where(p => p.Name != "Id" && p.CanRead)
            .ToArray();

        var setClause = string.Join(", ", properties.Select(p => $"{p.Name} = '{p.GetValue(entity)}'"));

        string script = $"UPDATE {TableName} SET {setClause} WHERE Id = {entity.Id}";
        UseScript(script);
        return entity;
    }

    private void UseScript(string script)
    {
        if (!string.IsNullOrEmpty(script))
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(script);
            }
    }
}