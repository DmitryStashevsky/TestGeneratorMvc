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
        public string Description { get; set; }

        public Test()
            : base()
        {
            Questions = new List<Question>();
            Users = new List<User>();
        }

        public List<Question> Questions { get; set; }

        public List<User> Users { get; set; }

    }
}
