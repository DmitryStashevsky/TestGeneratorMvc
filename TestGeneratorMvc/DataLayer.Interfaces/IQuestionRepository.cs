using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        List<Question> GetAllWithTag();

        List<Question> GetQuestionsForTest(Guid testId);

        List<Question> GetValidQuestionsForTest(Guid testId);

        List<Question> GetModifiedQuestionsForTest(Guid testId);
    }
}
