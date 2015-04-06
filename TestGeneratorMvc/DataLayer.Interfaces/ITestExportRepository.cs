using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Interfaces
{
    public interface ITestExportRepository : IRepository<TestExport>
    {
        List<TestExport> GetAllWithTest();
    }
}
