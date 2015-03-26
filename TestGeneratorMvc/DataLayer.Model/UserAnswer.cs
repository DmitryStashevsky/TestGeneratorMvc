using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserAnswer : BaseEntity
    {
        public UserAnswer()
            : base()
        {
            Answers = new List<Answer>();
        }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public Question Question { get; set; }
        public Guid QuestionId { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
