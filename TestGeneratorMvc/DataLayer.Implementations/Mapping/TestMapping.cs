using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Implementations.Mapping
{
    public class TestMapping : EntityTypeConfiguration<Test>
    {
        public TestMapping()
        {
            ToTable("Test");

            HasKey(e => e.Id);

            Property(e => e.Name).IsRequired();
            Property(e => e.CountOfQuestions).IsRequired();
            Property(e => e.CountOfAnswers).IsRequired();
            Property(e => e.CountOfRightAnswers).IsRequired();

            HasMany(e => e.Questions).WithMany(e => e.Tests).Map(e =>
                {
                    e.ToTable("TestQuestion");
                    e.MapLeftKey("TestId");
                    e.MapRightKey("QuestionId");
                });

            HasMany(e => e.Users).WithMany(e => e.Tests).Map(e =>
                {
                    e.ToTable("UserAndTest");
                    e.MapLeftKey("TestId");
                    e.MapRightKey("UserId");
                });
        }
    }
}
