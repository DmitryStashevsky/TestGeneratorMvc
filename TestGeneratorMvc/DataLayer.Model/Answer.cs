using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public class Answer : BaseEntity
    {
        [XmlAttribute("correct")]
        public bool IsCorrect { get; set; }

        [XmlText]
        public string Text { get; set; }

        public Answer()
            : base()
        {
            IsCorrect = false;
            Text = string.Empty;
            UserAnswers = new List<UserAnswer>();
        }

        public Question Question { get; set; }
        public Guid QuestionId { get; set; }

        public List<UserAnswer> UserAnswers { get; set; }
    }
}
