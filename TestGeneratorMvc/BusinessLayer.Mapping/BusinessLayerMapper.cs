using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.ApiModel;
using DataLayer.Model;
using DataLayer.XmlModel;

namespace BusinessLayer.Mapping
{
    public static class BusinessLayerMapper
    {
        public static void Map()
        {
            Mapper.CreateMap<XmlAnswer, Answer>();
            Mapper.CreateMap<XmlQuestion, Question>();
            Mapper.CreateMap<XmlTest, Test>();

            Mapper.CreateMap<ApiCreateQuestion, Question>();
            Mapper.CreateMap<Question, ApiShowQuestion>()
                .ForMember(d => d.ValidFrom, s => s.MapFrom(src => src.ValidFrom.ToShortDateString()))
                .ForMember(d => d.ValidTo, s => s.MapFrom(src => (src.ValidTo.HasValue) ? src.ValidTo.Value.ToShortDateString() : ""));
        }
    }
}
