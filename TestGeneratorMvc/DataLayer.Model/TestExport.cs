using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class TestExport : BaseEntity
    {
        public string Path { get; set; }
        public string VirtualPath { get; set; }
        public int NumberOfVariants { get; set; }
        public DateTime Created { get ;set; }

        public TestExport()
            : base()
        {
            Created = DateTime.Now;
        }

        public Test Test { get; set; }
        public Guid TestId { get; set; }

        public User User { get; set; }
        public Guid? UserId { get; set; }
    }
}
