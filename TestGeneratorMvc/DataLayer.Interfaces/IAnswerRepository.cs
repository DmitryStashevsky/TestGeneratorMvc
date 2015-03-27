using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        List<Answer> GetAnswerForQuestion(Guid questionId);

        List<Answer> GetRightAnswerForQuestion(Guid questionId);

        List<Answer> GetAnswersForUserAnswer(Guid userAnswerId);
    }
}
