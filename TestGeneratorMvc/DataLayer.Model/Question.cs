using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public class Question : BaseEntity
    {
        [XmlText]
        public string Text { get; set; }
        public DateTime ValidFrom { get ;set; }
        public DateTime ValidTo { get ;set; }
        public bool IsValid{ get ;set; }

        public Question() : base()
        {
            Text = string.Empty;
            ValidFrom = DateTime.Now;
            IsValid = true;
            Answers = new List<Answer>();
            UserAnswers = new List<UserAnswer>();
        }

        [XmlArray("answers")]
        [XmlArrayItem("answer")]
        public List<Answer> Answers { get; set; }

        public List<UserAnswer> UserAnswers { get; set; }

        public Question ParentQuestion { get; set; }
        public Guid? ParentQuestionId { get; set; }

        public Test Test { get; set; }
        public Guid TestId { get; set; }

    }
}
