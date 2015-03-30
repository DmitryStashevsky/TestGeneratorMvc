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
    public class QuestionCreateService : IQuestionCreateService
    {
        private IUnitOfWork m_UnitOfWork;
        private IQuestionRepository m_QuestionRepository;

        public QuestionCreateService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_QuestionRepository = m_UnitOfWork.GetRepository<IQuestionRepository>();
        }

        public string AddQuestion(ApiCreateQuestion question)
        {
            var s = new Question { Text = question.Text };
            m_QuestionRepository.Create(s);
            m_UnitOfWork.SaveChanges();
            return "success";
        }
    }
}
