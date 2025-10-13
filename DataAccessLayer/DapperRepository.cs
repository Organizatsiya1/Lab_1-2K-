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

    public DapperRepository()
    {
        ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Aster\\source\\repos\\Organizatsiya1\\Lab_1-2K-\\DataAccessLayer\\AdventureGuildDB.mdf;Integrated Security=True";
        InitializeCharactersTable();
    }

    private void InitializeCharactersTable()
    {
        using (var db = new SqlConnection(ConnectionString))
        {
            // Создаем таблицу если её нет
            db.Execute(@"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Characters' AND xtype='U')
                CREATE TABLE Characters (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(100) NOT NULL,
                    Description NVARCHAR(MAX),
                    HP INT NOT NULL DEFAULT 0,
                    Strength INT NOT NULL DEFAULT 0,
                    Stamina INT NULL,
                    Weapon INT NULL,
                    Mana INT NULL,
                    School INT NULL
                )");

            // Добавляем столбцы если их нет
            db.Execute(@"
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Characters') AND name = 'Stamina')
                ALTER TABLE Characters ADD Stamina INT NULL");

            db.Execute(@"
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Characters') AND name = 'Weapon')
                ALTER TABLE Characters ADD Weapon INT NULL");

            db.Execute(@"
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Characters') AND name = 'Mana')
                ALTER TABLE Characters ADD Mana INT NULL");

            db.Execute(@"
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Characters') AND name = 'School')
                ALTER TABLE Characters ADD School INT NULL");
        }
    }

    public T Create(T entity)
    {
        string script = @"INSERT INTO Characters (Name, Description, HP, Strength, Stamina, Weapon, Mana, School) 
                         VALUES (@Name, @Description, @HP, @Strength, @Stamina, @Weapon, @Mana, @School)";

        var parameters = new DynamicParameters();
        parameters.Add("Name", (entity as Character)?.Name);
        parameters.Add("Description", (entity as Character)?.Description);
        parameters.Add("HP", (entity as Character)?.HP);
        parameters.Add("Strength", (entity as Character)?.Strength);
        parameters.Add("Stamina", (entity as Fighter)?.Stamina);
        parameters.Add("Weapon", (entity as Fighter)?.Weapon);
        parameters.Add("Mana", (entity as Mage)?.Mana);
        parameters.Add("School", (entity as Mage)?.School);

        using (var db = new SqlConnection(ConnectionString))
        {
            db.Execute(script, parameters);
        }
        return entity;
    }

    public IEnumerable<T> ReadAll()
    {
        string script = "SELECT * FROM Characters";
        using (var db = new SqlConnection(ConnectionString))
        {
            // Используем dynamic для получения всех полей
            var characters = db.Query<dynamic>(script);

            var result = new List<T>();
            foreach (var character in characters)
            {
                // Приводим dynamic к конкретным типам
                int? stamina = character.Stamina;
                int? weapon = character.Weapon;
                int? mana = character.Mana;
                int? school = character.School;

                if (stamina.HasValue && weapon.HasValue)
                {
                    var fighter = new Fighter
                    {
                        Id = character.Id,
                        Name = character.Name,
                        Description = character.Description,
                        HP = character.HP,
                        Strength = character.Strength,
                        Stamina = stamina.Value,
                        Weapon = (Weapons)weapon.Value
                    };
                    result.Add((T)(object)fighter);
                }
                else if (mana.HasValue && school.HasValue)
                {
                    var mage = new Mage
                    {
                        Id = character.Id,
                        Name = character.Name,
                        Description = character.Description,
                        HP = character.HP,
                        Strength = character.Strength,
                        Mana = mana.Value,
                        School = (MagicSchools)school.Value
                    };
                    result.Add((T)(object)mage);
                }
            }
            return result;
        }
    }

    public void Delete(T entity)
    {
        string script = "DELETE FROM Characters WHERE Id = @Id";
        using (var db = new SqlConnection(ConnectionString))
        {
            db.Execute(script, new { entity.Id });
        }
    }

    public T ReadById(int id)
    {
        string script = "SELECT * FROM Characters WHERE Id = @Id";
        using (var db = new SqlConnection(ConnectionString))
        {
            var character = db.Query<dynamic>(script, new { Id = id }).FirstOrDefault();

            if (character == null) return null;

            int? stamina = character.Stamina;
            int? weapon = character.Weapon;
            int? mana = character.Mana;
            int? school = character.School;

            if (stamina.HasValue && weapon.HasValue)
            {
                var fighter = new Fighter
                {
                    Id = character.Id,
                    Name = character.Name,
                    Description = character.Description,
                    HP = character.HP,
                    Strength = character.Strength,
                    Stamina = stamina.Value,
                    Weapon = (Weapons)weapon.Value
                };
                return (T)(object)fighter;
            }
            else if (mana.HasValue && school.HasValue)
            {
                var mage = new Mage
                {
                    Id = character.Id,
                    Name = character.Name,
                    Description = character.Description,
                    HP = character.HP,
                    Strength = character.Strength,
                    Mana = mana.Value,
                    School = (MagicSchools)school.Value
                };
                return (T)(object)mage;
            }

            return null;
        }
    }

    public T Update(T entity)
    {
        string script = @"UPDATE Characters SET 
                         Name = @Name, 
                         Description = @Description, 
                         HP = @HP, 
                         Strength = @Strength, 
                         Stamina = @Stamina, 
                         Weapon = @Weapon, 
                         Mana = @Mana, 
                         School = @School
                         WHERE Id = @Id";

        var parameters = new DynamicParameters();
        parameters.Add("Id", (entity as Character)?.Id);
        parameters.Add("Name", (entity as Character)?.Name);
        parameters.Add("Description", (entity as Character)?.Description);
        parameters.Add("HP", (entity as Character)?.HP);
        parameters.Add("Strength", (entity as Character)?.Strength);
        parameters.Add("Stamina", (entity as Fighter)?.Stamina);
        parameters.Add("Weapon", (entity as Fighter)?.Weapon);
        parameters.Add("Mana", (entity as Mage)?.Mana);
        parameters.Add("School", (entity as Mage)?.School);

        using (var db = new SqlConnection(ConnectionString))
        {
            db.Execute(script, parameters);
        }
        return entity;
    }
}