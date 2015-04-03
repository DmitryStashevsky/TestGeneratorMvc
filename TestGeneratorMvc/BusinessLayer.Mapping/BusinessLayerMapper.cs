using System;
using System.Collections.Generic;
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

            Mapper.CreateMap<TestExport, ApiShowTestExportAfterCreate>();
            Mapper.CreateMap<TestExport, ApiShowTestExport>();
            Mapper.CreateMap<Test, ApiShowTestWithTestExport>();

            Mapper.CreateMap<Answer, ApiShowAnswer>();
            Mapper.CreateMap<Answer, ApiShowAnswerWithValue>();

            Mapper.CreateMap<Guid, Question>().ForMember(d => d.Id, s => s.MapFrom(src => new Question { Id = src }));
            Mapper.CreateMap<Question, Guid>().ConvertUsing(source => source.Id);

            Mapper.CreateMap<Test, ApiShowTest>().ForMember(d => d.CountOfPassedUsers, s => s.MapFrom(src => src.Users.Count));

            Mapper.CreateMap<ApiCreateTest, Test>();
            Mapper.CreateMap<ApiCreateQuestion, Question>().ForMember(d => d.Tags, s => s.Ignore());
            Mapper.CreateMap<ApiCreateAnswer, Answer>();
            Mapper.CreateMap<Question, ApiShowQuestion>()
                .ForMember(d => d.ValidFrom, s => s.MapFrom(src => src.ValidFrom.ToShortDateString()))
                .ForMember(d => d.ValidTo, s => s.MapFrom(src => (src.ValidTo.HasValue) ? src.ValidTo.Value.ToShortDateString() : ""))
                .ForMember(d => d.Tags, s => s.MapFrom(src => tagService.GetTagsToString(src.Tags)));
             Mapper.CreateMap<Question, ApiShowQuestionForTestCreate>()
                 .ForMember(d => d.Tags, s => s.MapFrom(src => tagService.GetTagsToString(src.Tags)));
             Mapper.CreateMap<Question, ApiShowQuestionForTestView>();
        }
    }
}
