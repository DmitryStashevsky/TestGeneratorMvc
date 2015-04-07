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
    public class AnswerService : IAnswerService
    {
        private IUnitOfWork m_UnitOfWork;
        private IAnswerRepository m_AnswerRepository;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_AnswerRepository = m_UnitOfWork.GetRepository<IAnswerRepository>();
        }

        public List<ApiShowAnswer> GetAnswersForQuestion(Guid questionId)
        {
            return Mapper.Map<List<ApiShowAnswer>>(m_AnswerRepository.GetAnswerForQuestion(questionId));
        }

        public List<ApiShowAnswerWithValue> GetAnswersForQuestionWithRightValues(Guid questionId)
        {
            return Mapper.Map<List<ApiShowAnswerWithValue>>(m_AnswerRepository.GetAnswerForQuestion(questionId));
        }
    }
}
