using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Implementations.Mapping;

namespace DataLayer.Implementations.ApplicationDbContext
{
    public class TestGeneratorDbContext : DbContext
    {
        public TestGeneratorDbContext(string connectionString = "DefaultConnection")
            : base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TestGeneratorDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnswerMapping());
            modelBuilder.Configurations.Add(new QuestionMapping());
            modelBuilder.Configurations.Add(new TestMapping());
            modelBuilder.Configurations.Add(new TestExportMapping());
            modelBuilder.Configurations.Add(new UserAnswerMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new TagMapping());
        }
    }
}
