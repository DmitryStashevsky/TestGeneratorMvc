using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.ApiModel;

namespace BusinessLayer.Interfaces
{
    public interface IAnswerService
    {
        List<ApiShowAnswer> GetAnswersForQuestion(Guid questionId);

        List<ApiShowAnswerWithValue> GetAnswersForQuestionWithRightValues(Guid questionId);
    }
}
