using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataLayer.ApiModel;
using DataLayer.ExportModel;
using DataLayer.Model;
using DataLayer.XmlModel;

namespace BusinessLayer.Mapping
{
    public static class BusinessLayerMapper
    {
        public static void Map(ITagService tagService)
        {
            Mapper.CreateMap<XmlAnswer, Answer>();
            Mapper.CreateMap<XmlQuestion, Question>();
            Mapper.CreateMap<XmlTest, Test>();

            Mapper.CreateMap<Answer, ExportAnswer>();
            Mapper.CreateMap<Question, ExportQuestion>();
            Mapper.CreateMap<Test, ExportTest>();
            Mapper.CreateMap<ExportTest, ExportTestForOutput>();
            Mapper.CreateMap<User, ApiShowUser>();
            Mapper.CreateMap<User, ApiViewUserWithInfo>()
                .ForMember(d => d.CreatedQuestions, s => s.MapFrom(src => src.Questions.Count))
                .ForMember(d => d.CreatedTests, s => s.MapFrom(src => src.OwnerTests.Count))
                .ForMember(d => d.CreatedTestExports, s => s.MapFrom(src => src.TestExports.Count))
                .ForMember(d => d.PassedTests, s => s.MapFrom(src => src.Tests.Count));

            Mapper.CreateMap<TestExport, ApiShowTestExportAfterCreate>(); 
            Mapper.CreateMap<TestExport, ApiShowTestExport>();
            Mapper.CreateMap<TestExport, ApiShowTestExportWithTestInfo>()
                .ForMember(d => d.Created, s => s.MapFrom(src => src.Created.ToString("G")));
            Mapper.CreateMap<Test, ApiShowTestWithTestExport>();

            Mapper.CreateMap<Answer, ApiShowAnswer>();
            Mapper.CreateMap<Answer, ApiShowAnswerWithValue>();

            Mapper.CreateMap<Guid, Question>().ForMember(d => d.Id, s => s.MapFrom(src => new Question { Id = src }));
            Mapper.CreateMap<Question, Guid>().ConvertUsing(source => source.Id);

            Mapper.CreateMap<Test, ApiShowTest>().ForMember(d => d.CountOfPassedUsers, s => s.MapFrom(src => src.Users.Count));
            Mapper.CreateMap<Test, ApiShowTestWithOwner>().ForMember(d => d.CountOfPassedUsers, s => s.MapFrom(src => src.Users.Count));

            Mapper.CreateMap<ApiCreateTest, Test>();
            Mapper.CreateMap<ApiCreateQuestion, Question>().ForMember(d => d.Tags, s => s.Ignore());
            Mapper.CreateMap<ApiCreateAnswer, Answer>();
            Mapper.CreateMap<Question, ApiShowQuestion>()
                .ForMember(d => d.ValidFrom, s => s.MapFrom(src => src.ValidFrom.ToString("G")))
                .ForMember(d => d.ValidTo, s => s.MapFrom(src => (src.ValidTo.HasValue) ? src.ValidTo.Value.ToString("G") : ""))
                .ForMember(d => d.Tags, s => s.MapFrom(src => tagService.GetTagsToString(src.Tags)));
            Mapper.CreateMap<Question, ApiShowQuestionWithUser>()
                .ForMember(d => d.ValidFrom, s => s.MapFrom(src => src.ValidFrom.ToString("G")))
                .ForMember(d => d.ValidTo, s => s.MapFrom(src => (src.ValidTo.HasValue) ? src.ValidTo.Value.ToString("G") : ""))
                .ForMember(d => d.Tags, s => s.MapFrom(src => tagService.GetTagsToString(src.Tags)))
                .ForMember(d => d.User, s => s.MapFrom(src => src.Owner));
            Mapper.CreateMap<Question, ApiShowQuestionForTestCreate>()
                .ForMember(d => d.Tags, s => s.MapFrom(src => tagService.GetTagsToString(src.Tags)));
            Mapper.CreateMap<Question, ApiShowQuestionForTestView>();
        }
    }
}
