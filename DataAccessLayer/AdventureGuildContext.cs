using Models;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class AdventureGuildContext : DbContext
    {
        static AdventureGuildContext()
        {
            // Эта строка гарантирует, что EF.SqlServer библиотека будет загружена в рантайме
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public AdventureGuildContext() : base("name=AdventureGuildDB") 
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AdventureGuildContext>());
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<Mage> Mages { get; set; }

        /// <summary>
        /// Настраивает модель, которая была обнаружена по соглашению из типов сущностей,
        /// представленных в свойствах DbSet в производном контексте
        /// </summary>
        /// <param name="modelBuilder">Построитель, используемый для конструирования модели для этого контекста</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>().ToTable("Персонажи");
            modelBuilder.Entity<Fighter>().ToTable("Воины");
            modelBuilder.Entity<Mage>().ToTable("Маги");
        }
    }
}
