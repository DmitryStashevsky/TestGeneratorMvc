using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLayer.XmlModel
{
    public class XmlAnswer
    {
        [XmlAttribute("correct")]
        public bool IsCorrect { get; set; }

        [XmlText]
        public string Text { get; set; }

        public XmlAnswer()
        {
            IsCorrect = false;
            Text = string.Empty;
        }
    }
}
