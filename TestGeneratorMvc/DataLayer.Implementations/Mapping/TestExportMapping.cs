using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Implementations.Mapping
{
    public class TestExportMapping : EntityTypeConfiguration<TestExport>
    {
        public TestExportMapping()
        {
            ToTable("TestExport");

            HasKey(e => e.Id);

            Property(e => e.Path).IsRequired();
            Property(e => e.VirtualPath).IsRequired();
            Property(e => e.NumberOfVariants).IsRequired();
            Property(e => e.Created).IsRequired().HasColumnType("datetime2");

            HasRequired(e => e.Test).WithMany(e => e.TestExports).HasForeignKey(e => e.TestId);

            //TO-DO change hasrequired
            HasOptional(e => e.User).WithMany(e => e.TestExports).HasForeignKey(e => e.UserId);
        }

    }
}
