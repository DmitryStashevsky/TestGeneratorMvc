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
    public class TestCreateService : ITestCreateService
    {
        private IUnitOfWork m_UnitOfWork;
        private IQuestionRepository m_QuestionRepository;
        private ITestRepository m_TestRepository;

        public TestCreateService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_QuestionRepository = m_UnitOfWork.GetRepository<IQuestionRepository>();
            m_TestRepository = m_UnitOfWork.GetRepository<ITestRepository>();
        }

        public List<ApiQuestion> GetQuestions()
        {
            return Mapper.Map<List<ApiQuestion>>(m_QuestionRepository.GetAll());
        }

        public void CreateTest(ApiCreateTest test)
        {
            throw new NotImplementedException();
        }
    }
}
