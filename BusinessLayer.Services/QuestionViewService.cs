using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataLayer.ApiModel;
using DataLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class QuestionViewService : IQuestionViewService
    {
        private IUnitOfWork m_UnitOfWork;
        private IQuestionRepository m_QuestionRepository;

        public QuestionViewService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_QuestionRepository = m_UnitOfWork.GetRepository<IQuestionRepository>();
        }

        public List<ApiShowQuestion> GetQuestions()
        {
            return Mapper.Map<List<ApiShowQuestion>>(m_QuestionRepository.GetAllWithTag());
        }

        public List<ApiShowQuestionWithUser> GetQuestionsWithUser()
        {
            return Mapper.Map<List<ApiShowQuestionWithUser>>(m_QuestionRepository.GetAllWithTagAndUser());
        }

        public List<ApiShowQuestionForTestView> GetQuestionsForTest(Guid testId)
        {
            return Mapper.Map<List<ApiShowQuestionForTestView>>(m_QuestionRepository.GetQuestionsForTest(testId));
        }

        public int GetQuestionsCount()
        {
            return m_QuestionRepository.Count;
        }
    }
}
