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

        public int GetQuestionsCount()
        {
            return m_QuestionRepository.Count;
        }
    }
}
