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
    public class UserAnswerRepository : Repository<UserAnswer>, IUserAnswerRepository
    {
        public UserAnswerRepository(DbContext context)
            : base(context)
        {
        }

        public UserAnswer GetUserAnswerForQuestion(Guid questionId)
        {
            return m_Context.Set<UserAnswer>().AsNoTracking().FirstOrDefault(e => e.QuestionId == questionId);
        }

        public List<UserAnswer> GetUserAnswersForUser(Guid userId)
        {
            return m_Context.Set<UserAnswer>().AsNoTracking().Where(e => e.UserId == userId).ToList();
        }
    }
}
