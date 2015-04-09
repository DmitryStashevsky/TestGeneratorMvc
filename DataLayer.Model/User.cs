using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public User()
            : base()
        {
            Questions = new List<Question>();
            Tests = new List<Test>();
            OwnerTests = new List<Test>();
            TestExports = new List<TestExport>();
            UserAnswers = new List<UserAnswer>();
        }

        public List<Question> Questions { get; set; }
        public List<Test> Tests { get; set; }
        public List<Test> OwnerTests { get; set; }
        public List<TestExport> TestExports { get; set; }
        public List<UserAnswer> UserAnswers { get; set; } 
    }
}
