using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer.Implementations.Mapping
{
    public class TestMapping : EntityTypeConfiguration<Test>
    {
        public TestMapping()
        {
            ToTable("Test");

            HasKey(e => e.Id);

            Property(e => e.Description).IsRequired();

            HasMany(e => e.Questions).WithRequired(e => e.Test).HasForeignKey(e => e.TestId).WillCascadeOnDelete();

            HasMany(e => e.Users).WithMany(e => e.Tests).Map(e =>
                {
                    e.ToTable("UserAndTest");
                    e.MapLeftKey("TestId");
                    e.MapRightKey("UserId");
                });
        }
    }
}
