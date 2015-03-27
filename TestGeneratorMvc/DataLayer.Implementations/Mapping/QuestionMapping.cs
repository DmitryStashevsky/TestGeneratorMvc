using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Implementations.Mapping
{
    public class QuestionMapping : EntityTypeConfiguration<Question>
    {
        public QuestionMapping()
        {
            ToTable("Question");

            HasKey(e => e.Id);

            Property(e => e.Text).IsRequired();
            Property(e => e.Rating).IsOptional();
            Property(e => e.Complexity).IsRequired();

            Property(e => e.ValidFrom).IsRequired();
            Property(e => e.ValidTo).IsOptional();

            Property(e => e.IsValid).IsRequired();

            HasOptional(e => e.ParentQuestion).WithMany().HasForeignKey(e => e.ParentQuestionId);

            HasMany(e => e.Answers).WithRequired(e => e.Question).HasForeignKey(e => e.QuestionId).WillCascadeOnDelete(false);
        }
    }
}
