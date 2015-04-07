using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataLayer.ApiModel;
using DataLayer.Interfaces;
using DataLayer.Model;

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

        public List<ApiShowQuestionForTestCreate> GetQuestionsForTestCreate()
        {
            return Mapper.Map<List<ApiShowQuestionForTestCreate>>(m_QuestionRepository.GetAllWithTag());
        }

        public string AddTest(ApiCreateTest test)
        {
            Test newTest = Mapper.Map<Test>(test);
            //atach questions to context
            foreach(var question in newTest.Questions)
            {
                m_QuestionRepository.Attach(question);
            }
            m_TestRepository.Create(newTest);
            m_UnitOfWork.SaveChanges();
            return "Successfully added new test";
        }
    }
}
