using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Implementations.Mapping
{
    public class TagMapping : EntityTypeConfiguration<Tag>
    {
        public TagMapping()
        {
            ToTable("Tag");

            HasKey(e => e.Id);

            HasMany(e => e.Questions).WithMany(e => e.Tags).Map(e =>
                {
                    e.ToTable("TagQuestion");
                    e.MapLeftKey("TagId");
                    e.MapRightKey("QuestionId");
                });
        }
    }
}
