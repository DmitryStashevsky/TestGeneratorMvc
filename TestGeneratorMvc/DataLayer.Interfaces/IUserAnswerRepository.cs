using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer.Interfaces
{
    public interface IUserAnswerRepository : IRepository<UserAnswer>
    {
        UserAnswer GetUserAnswerForQuestion(Guid questionId);

        List<UserAnswer> GetUserAnswersForUser(Guid userId);
    }
}
