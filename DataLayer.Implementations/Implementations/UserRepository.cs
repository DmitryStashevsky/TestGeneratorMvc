using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.Model;

namespace DataLayer.Implementations.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {
        }

        public List<User> GetAllWithInfo()
        {
            //TO-DO user another way to get count of linked entities
            return m_Context.Set<User>().AsNoTracking().Include(e => e.Questions).Include(e => e.TestExports).Include(e => e.OwnerTests).Include(e => e.Tests).ToList();
        }
    }
}
