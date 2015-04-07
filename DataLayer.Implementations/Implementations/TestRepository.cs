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
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public List<Test> GetAllWithUsers()
        {
            return m_Context.Set<Test>().AsNoTracking().Include(e => e.Users).ToList();
        }

        public List<Test> GetAllWithTestExport()
        {
            return m_Context.Set<Test>().AsNoTracking().Where(e => e.TestExports.Count > 0).Include(e => e.TestExports).ToList();
        }

        public Test GetByIdWithQuestionsAndAnswers(Guid id)
        {
            return m_Context.Set<Test>().Include(e => e.Questions.Select(q => q.Answers)).FirstOrDefault(e => e.Id == id);
        }

        public TestRepository(DbContext context)
            : base(context)
        {
        }
    }
}
