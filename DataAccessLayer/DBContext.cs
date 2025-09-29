using BusinessLogicModels;
using System.Data.Entity;

namespace DataAccessLayer
{
    // DBContext - 5a.i
    public class AdventureGuildContext : DbContext
    {
        public AdventureGuildContext() : base("name=AdventureGuildDB") { }

        public DbSet<Character> Characters { get; set; }

        /// <summary>
        /// Настраивает модель, которая была обнаружена по соглашению из типов сущностей,
        /// представленных в свойствах DbSet в производном контексте
        /// </summary>
        /// <param name="modelBuilder">Построитель, используемый для конструирования модели для этого контекста</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>().ToTable("Персонажи");
        }

    }
}
