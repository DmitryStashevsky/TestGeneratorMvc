using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public User()
            : base()
        {
            Tests = new List<Test>();
            UserAnswers = new List<UserAnswer>();
            TestExports = new List<TestExport>();
        }

        public List<Test> Tests { get; set; }
        public List<TestExport> TestExports { get; set; }
        public List<UserAnswer> UserAnswers { get; set; }
    }
}
