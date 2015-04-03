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
        private ITagRepository m_TagRepository;

        public QuestionCreateService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_QuestionRepository = m_UnitOfWork.GetRepository<IQuestionRepository>();
            m_TagRepository = m_UnitOfWork.GetRepository<ITagRepository>();
        }

        public string AddQuestion(ApiCreateQuestion question)
        {
            Question newQuestion = Mapper.Map<Question>(question);
            List<string> tagsInText = question.Tags.Split(' ').ToList();
            //TO-DO: Need more flexible way to save tags (in mapping for example)
            m_TagRepository.CreateTagsWhichNotExists(tagsInText);
            newQuestion.Tags = m_TagRepository.GetTagsForText(tagsInText);
            m_QuestionRepository.Create(newQuestion);
            m_UnitOfWork.SaveChanges();
            return "Successfully added new question";
        }
    }
}
