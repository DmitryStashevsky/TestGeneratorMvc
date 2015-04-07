using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLayer.XmlModel
{
    [XmlRoot("Test")]
    public class XmlTest
    {
        [XmlArray("questions")]
        [XmlArrayItem("question")]
        public List<XmlQuestion> Questions { get; set; }

        public XmlTest()
        {
            Questions = new List<XmlQuestion>(100);
        }
    }
}
