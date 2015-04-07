using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using DataLayer.ApiModel;

namespace TestGeneratorMvc.Controllers.ApiControllers
{
    public class QuestionController : ApiController
    {
        private IQuestionCreateService m_QuestionCreateService;
        private IQuestionViewService m_QuestionViewService;
        private IQuestionImportService m_QuestionImportService;

        public QuestionController()
        {
            m_QuestionCreateService = DependencyResolver.Current.GetService<IQuestionCreateService>();
            m_QuestionViewService = DependencyResolver.Current.GetService<IQuestionViewService>();
            m_QuestionImportService = DependencyResolver.Current.GetService<IQuestionImportService>();
        }

        public List<ApiShowQuestion> GetQuestion()
        {
            return m_QuestionViewService.GetQuestions();
        }

        public int GetQuestionCount()
        {
            return m_QuestionViewService.GetQuestionsCount();
        }

        [System.Web.Http.HttpPost]
        public string AddQuestion(ApiCreateQuestion question)
        {
            return m_QuestionCreateService.AddQuestion(question);
        }
    }
}
