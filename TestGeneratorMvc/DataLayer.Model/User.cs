using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public User()
            : base()
        {
            Tests = new List<Test>();
            UserAnswers = new List<UserAnswer>(); 
        }

        public List<Test> Tests { get; set; }
        public List<UserAnswer> UserAnswers { get; set; }

    }
}
