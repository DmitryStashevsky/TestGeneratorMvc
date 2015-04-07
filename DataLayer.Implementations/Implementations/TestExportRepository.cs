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
    public class TestExportRepository : Repository<TestExport>, ITestExportRepository
    {
        public TestExportRepository(DbContext context)
            : base(context)
        {
        }

        public List<TestExport> GetAllWithTest()
        {
            return m_Context.Set<TestExport>().AsNoTracking().Include(e => e.Test).ToList();
        }
    }
}
