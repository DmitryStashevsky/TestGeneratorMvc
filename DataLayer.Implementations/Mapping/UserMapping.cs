using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Implementations.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("User");

            HasKey(e => e.Id);

            Property(e => e.UserName).IsRequired();

            HasMany(e => e.Tests).WithMany(e => e.Users).Map(e =>
                {
                    e.ToTable("TestUsers");
                    e.MapLeftKey("UserId");
                    e.MapRightKey("TestId");
                });
        }
    }
}
