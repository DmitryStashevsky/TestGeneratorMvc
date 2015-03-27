using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLayer.Model
{
    public class Answer : BaseEntity
    {
        public bool IsCorrect { get; set; }

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
