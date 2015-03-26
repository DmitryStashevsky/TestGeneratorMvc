using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using Model;

namespace DataLayer.Implementations.Implementations
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(DbContext context)
            : base(context)
        {
        }
    }
}
