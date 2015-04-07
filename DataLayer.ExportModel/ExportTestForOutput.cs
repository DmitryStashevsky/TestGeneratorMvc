using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExportModel
{
    public class ExportTestForOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExportQuestion> Questions { get; set; }
    }
}
