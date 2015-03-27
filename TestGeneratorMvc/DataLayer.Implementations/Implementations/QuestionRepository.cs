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
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(DbContext context)
            : base(context)
        {
        }

        public List<Question> GetQuestionsForTest(Guid testId)
        {
            return m_Context.Set<Question>().AsNoTracking().Where(e => e.Tests.Any(t => t.Id == testId)).ToList();
        }

        public List<Question> GetValidQuestionsForTest(Guid testId)
        {
            return m_Context.Set<Question>().AsNoTracking().Where(e => e.Tests.Any(t => t.Id == testId) && e.IsValid).ToList();
        }

        public List<Question> GetModifiedQuestionsForTest(Guid testId)
        {
            return m_Context.Set<Question>().AsNoTracking().Where(e => e.Tests.Any(t => t.Id == testId) && !e.IsValid).ToList();
        }
    }
}
