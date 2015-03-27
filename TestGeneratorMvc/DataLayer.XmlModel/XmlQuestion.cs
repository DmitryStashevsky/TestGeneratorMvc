using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLayer.XmlModel
{
    public class XmlQuestion
    {
        [XmlText]
        public string Text { get; set; }

        [XmlArray("answers")]
        [XmlArrayItem("answer")]
        public List<XmlAnswer> Answers { get; set; }

        public XmlQuestion()
        {
            Text = string.Empty;
            Answers = new List<XmlAnswer>(10);
        }
    }
}
