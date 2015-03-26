using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer.Implementations.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("User");

            HasKey(e => e.Id);

            Property(e => e.Name).IsRequired();

            HasMany(e => e.UserAnswers).WithRequired(e => e.User).HasForeignKey(e => e.UserId).WillCascadeOnDelete();
        }
    }
}
