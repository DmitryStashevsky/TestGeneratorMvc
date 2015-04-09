using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLayer.Model
{
    public class Test : BaseEntity
    {
        public string Name { get; set; }
        public int CountOfQuestions { get; set; }
        public int CountOfAnswers { get; set; }
        public int CountOfRightAnswers { get; set; }

        public Test()
            : base()
        {
            Questions = new List<Question>();
            TestExports = new List<TestExport>();
            Users = new List<User>();
        }

        public List<Question> Questions { get; set; }
        public List<TestExport> TestExports { get; set; }
        public List<User> Users { get; set; }

        public User Owner { get; set; }
        public Guid OwnerId { get; set; }
    }
}
