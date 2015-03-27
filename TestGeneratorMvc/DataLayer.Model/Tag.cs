using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Tag : BaseEntity
    {
        public string Text { get; set; }

        public Tag()
            : base()
        {
            Text = string.Empty;
        }

        public List<Question> Questions { get; set; }
    }
}
