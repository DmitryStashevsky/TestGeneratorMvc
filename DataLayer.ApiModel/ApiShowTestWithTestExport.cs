using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ApiModel
{
    public class ApiShowTestWithTestExport : ApiBaseEntity
    {
        public string Name { get; set; }
        public int CountOfQuestions { get; set; }
        public int CountOfAnswers { get; set; }
        public int CountOfRightAnswers { get; set; }

        public List<ApiShowTestExport> TestExports { get; set; }
    }
}
