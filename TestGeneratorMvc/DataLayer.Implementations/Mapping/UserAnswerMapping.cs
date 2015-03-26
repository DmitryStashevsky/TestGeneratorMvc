using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer.Implementations.Mapping
{
    public class UserAnswerMapping : EntityTypeConfiguration<UserAnswer>
    {
        public UserAnswerMapping()
        {
            ToTable("UserAnswer");

            HasKey(e => e.Id);

            HasMany(e => e.Answers).WithMany(e => e.UserAnswers).Map(e =>
                {
                    e.ToTable("UserAnswerAndAnswer");
                    e.MapLeftKey("UserAnswerId");
                    e.MapRightKey("AnswerId");
                });
            HasRequired(e => e.Question).WithMany(e => e.UserAnswers).HasForeignKey(e => e.QuestionId);
        }
    }
}
