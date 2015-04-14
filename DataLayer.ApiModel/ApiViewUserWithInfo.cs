using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ApiModel
{
    public class ApiViewUserWithInfo : ApiBaseEntity
    {
        public string UserName { get; set; }
        public int CreatedQuestions { get; set; }
        public int PassedTests { get; set; }
        public int CreatedTests { get; set; }
        public int CreatedTestExports { get; set; }
    }
}
