using Dapper;
using DataAccessLayer;
using Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
{
    private readonly string ConnectionString;

    public DapperRepository()
    {
        ConnectionString = ConfigurationManager.ConnectionStrings["AdventureGuildDB"].ConnectionString;
        InitializeTables();
    }

    /// <summary>
    /// При запуске приводим БД в ожидаемое состояние:
    /// удаляем старую таблицу Characters (если есть) и создаём две таблицы: Fighters и Mages
    /// </summary>
    private void InitializeTables()
    {
        using (var db = new SqlConnection(ConnectionString))
        {
            // Drop old combined table if exists and any old per-type tables, then recreate per-type tables
            db.Execute(@"
                IF OBJECT_ID('dbo.Characters', 'U') IS NOT NULL
                    DROP TABLE dbo.Characters;
                IF OBJECT_ID('dbo.Fighters', 'U') IS NOT NULL
                    DROP TABLE dbo.Fighters;
                IF OBJECT_ID('dbo.Mages', 'U') IS NOT NULL
                    DROP TABLE dbo.Mages;

                CREATE TABLE Fighters (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(100) NOT NULL,
                    Description NVARCHAR(MAX),
                    HP INT NOT NULL DEFAULT 0,
                    Strength INT NOT NULL DEFAULT 0,
                    Stamina INT NOT NULL DEFAULT 0,
                    Weapon INT NOT NULL DEFAULT 0
                );

                CREATE TABLE Mages (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(100) NOT NULL,
                    Description NVARCHAR(MAX),
                    HP INT NOT NULL DEFAULT 0,
                    Strength INT NOT NULL DEFAULT 0,
                    Mana INT NOT NULL DEFAULT 0,
                    School INT NOT NULL DEFAULT 0
                );
            ");
        }
    }

    public T Create(T entity)
    {
        using (var db = new SqlConnection(ConnectionString))
        {
            if (entity is Fighter f)
            {
                string script = @"INSERT INTO Fighters (Name, Description, HP, Strength, Stamina, Weapon)
                                  VALUES (@Name, @Description, @HP, @Strength, @Stamina, @Weapon);
                                  SELECT CAST(SCOPE_IDENTITY() as int);";
                var id = db.Query<int>(script, new { f.Name, f.Description, f.HP, f.Strength, f.Stamina, Weapon = (int)f.Weapon }).First();
                f.Id = id;
                return entity;
            }
            else if (entity is Mage m)
            {
                string script = @"INSERT INTO Mages (Name, Description, HP, Strength, Mana, School)
                                  VALUES (@Name, @Description, @HP, @Strength, @Mana, @School);
                                  SELECT CAST(SCOPE_IDENTITY() as int);";
                var id = db.Query<int>(script, new { m.Name, m.Description, m.HP, m.Strength, m.Mana, School = (int)m.School }).First();
                m.Id = id;
                return entity;
            }

            // Unsupported type: do nothing
            return entity;
        }
    }

    public IEnumerable<T> ReadAll()
    {
        var result = new List<T>();
        using (var db = new SqlConnection(ConnectionString))
        {
            // Read fighters
            var fighters = db.Query(@"SELECT * FROM Fighters");
            foreach (var r in fighters)
            {
                var fighter = new Fighter
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    HP = r.HP,
                    Strength = r.Strength,
                    Stamina = r.Stamina,
                    Weapon = (Weapons)r.Weapon
                };
                if (typeof(T).IsAssignableFrom(typeof(Fighter)))
                    result.Add((T)(object)fighter);
                else if (typeof(T) == typeof(object) || typeof(T) == typeof(IDomainObject))
                    result.Add((T)(object)fighter);
            }

            // Read mages
            var mages = db.Query(@"SELECT * FROM Mages");
            foreach (var r in mages)
            {
                var mage = new Mage
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    HP = r.HP,
                    Strength = r.Strength,
                    Mana = r.Mana,
                    School = (MagicSchools)r.School
                };
                if (typeof(T).IsAssignableFrom(typeof(Mage)))
                    result.Add((T)(object)mage);
                else if (typeof(T) == typeof(object) || typeof(T) == typeof(IDomainObject))
                    result.Add((T)(object)mage);
            }
        }
        return result;
    }

    public void Delete(T entity)
    {
        using (var db = new SqlConnection(ConnectionString))
        {
            if (entity is Fighter)
            {
                db.Execute("DELETE FROM Fighters WHERE Id = @Id", new { entity.Id });
            }
            else if (entity is Mage)
            {
                db.Execute("DELETE FROM Mages WHERE Id = @Id", new { entity.Id });
            }
        }
    }

    public T ReadById(int id)
    {
        using (var db = new SqlConnection(ConnectionString))
        {
            var r = db.Query("SELECT * FROM Fighters WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            if (r != null)
            {
                var fighter = new Fighter
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    HP = r.HP,
                    Strength = r.Strength,
                    Stamina = r.Stamina,
                    Weapon = (Weapons)r.Weapon
                };
                return (T)(object)fighter;
            }

            r = db.Query("SELECT * FROM Mages WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            if (r != null)
            {
                var mage = new Mage
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    HP = r.HP,
                    Strength = r.Strength,
                    Mana = r.Mana,
                    School = (MagicSchools)r.School
                };
                return (T)(object)mage;
            }

            return null;
        }
    }

    public T Update(T entity)
    {
        using (var db = new SqlConnection(ConnectionString))
        {
            if (entity is Fighter f)
            {
                string script = @"UPDATE Fighters SET
                                    Name = @Name,
                                    Description = @Description,
                                    HP = @HP,
                                    Strength = @Strength,
                                    Stamina = @Stamina,
                                    Weapon = @Weapon
                                  WHERE Id = @Id";
                db.Execute(script, new { f.Name, f.Description, f.HP, f.Strength, f.Stamina, Weapon = (int)f.Weapon, f.Id });
                return entity;
            }
            else if (entity is Mage m)
            {
                string script = @"UPDATE Mages SET
                                    Name = @Name,
                                    Description = @Description,
                                    HP = @HP,
                                    Strength = @Strength,
                                    Mana = @Mana,
                                    School = @School
                                  WHERE Id = @Id";
                db.Execute(script, new { m.Name, m.Description, m.HP, m.Strength, m.Mana, School = (int)m.School, m.Id });
                return entity;
            }

            return entity;
        }
    }
}