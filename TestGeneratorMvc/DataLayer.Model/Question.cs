using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLayer.Model
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public int Rating { get; set; }
        public int Complexity { get; set; }
	    public DateTime ValidFrom { get ;set; }
        public DateTime ValidTo { get ;set; }
        public bool IsValid{ get ;set; }

        public Question() : base()
        {
            Text = string.Empty;
            Complexity = 0;
            ValidFrom = DateTime.Now;
            IsValid = true;
            Answers = new List<Answer>();
            UserAnswers = new List<UserAnswer>();
            Tests = new List<Test>();
        }

        public List<Answer> Answers { get; set; }

        public List<UserAnswer> UserAnswers { get; set; }

        public List<Test> Tests { get; set; }

        public List<Tag> Tags{ get; set; }

        public Question ParentQuestion { get; set; }
        public Guid? ParentQuestionId { get; set; }
    }
}
