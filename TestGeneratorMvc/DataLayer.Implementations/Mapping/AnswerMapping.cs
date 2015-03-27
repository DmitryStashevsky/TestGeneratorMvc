using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Implementations.Mapping
{
    public class AnswerMapping : EntityTypeConfiguration<Answer>
    {
        public AnswerMapping()
        {
            ToTable("Answer");

            HasKey(e => e.Id);

            Property(e => e.Text).IsRequired();
            Property(e => e.IsCorrect).IsRequired();
        }
    }
}
