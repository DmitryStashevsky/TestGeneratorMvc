using System.IO;
using System.Xml.Serialization;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataLayer.Implementations.ApplicationDbContext;
using DataLayer.Implementations.Implementations;
using DataLayer.Interfaces;
using DataLayer.Model;
using DataLayer.XmlModel;

namespace BusinessLayer.Services.TestImport
{
    public class TestImportService : ITestImportService
    {
        private IUnitOfWork m_UnitOfWork;
        private ITestRepository m_TestRepository;

        private static ITestImportService m_Instance;

        private TestImportService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_TestRepository = unitOfWork.GetRepository<ITestRepository>();
            AddAutoMapperConfiguration();
        }

        public static ITestImportService Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new TestImportService(new UnitOfWork(new TestGeneratorDbContext()));
                }
                return m_Instance;
            }
        }

        public void Import(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(XmlTest));
            var xmlTest = (XmlTest) serializer.Deserialize(stream);
            Test test = Mapper.Map<Test>(xmlTest);
            m_TestRepository.Create(test);
            m_UnitOfWork.SaveChanges();
        }

        private void AddAutoMapperConfiguration()
        {
            Mapper.CreateMap<XmlAnswer, Answer>();
            Mapper.CreateMap<XmlQuestion, Question>();
            Mapper.CreateMap<XmlTest, Test>();
        }
    }
}
