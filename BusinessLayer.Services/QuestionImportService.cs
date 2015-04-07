using System.IO;
using System.Xml.Serialization;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataLayer.Implementations.ApplicationDbContext;
using DataLayer.Implementations.Implementations;
using DataLayer.Interfaces;
using DataLayer.Model;
using DataLayer.XmlModel;

namespace BusinessLayer.Services
{
    public class QuestionImportService : IQuestionImportService
    {
        private IUnitOfWork m_UnitOfWork;
        private IQuestionRepository m_QuestionRepository;

        public QuestionImportService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_QuestionRepository = unitOfWork.GetRepository<IQuestionRepository>();
        }

        public void Import(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(XmlTest));
            var xmlTest = (XmlTest) serializer.Deserialize(stream);
            Test test = Mapper.Map<Test>(xmlTest);
            foreach (var question in test.Questions)
            {
                m_QuestionRepository.Create(question);
            }
            m_UnitOfWork.SaveChanges();
        }
    }
}
