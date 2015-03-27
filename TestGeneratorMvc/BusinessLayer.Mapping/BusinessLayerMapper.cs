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

            Mapper.CreateMap<ApiQuestion, Question>();
            Mapper.CreateMap<Question, ApiQuestion>();
        }
    }
}
