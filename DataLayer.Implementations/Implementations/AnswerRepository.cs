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
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(DbContext context)
            : base(context)
        {
        }

        public List<Answer> GetAnswerForQuestion(Guid questionId)
        {
            return m_Context.Set<Answer>().AsNoTracking().Where(e => e.QuestionId == questionId).ToList();
        }

        public List<Answer> GetRightAnswerForQuestion(Guid questionId)
        {
            return m_Context.Set<Answer>().AsNoTracking().Where(e => e.QuestionId == questionId && e.IsCorrect).ToList();
        }

        public List<Answer> GetAnswersForUserAnswer(Guid userAnswerId)
        {
            return m_Context.Set<UserAnswer>().AsNoTracking().FirstOrDefault(e => e.Id == userAnswerId).Answers;
        }
    }
}
