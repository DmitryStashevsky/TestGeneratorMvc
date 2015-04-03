using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExportModel
{
    public class ExportTest
    {
        public string Name { get; set; }
        public int CountOfQuestions { get; set; }
        public int CountOfAnswers { get; set; }
        public int CountOfRightAnswers { get; set; }
        public List<ExportQuestion> Questions { get; set; }
    }
}
