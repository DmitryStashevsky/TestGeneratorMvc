using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExportModel
{
    public class ExportQuestion : ExportBaseEntity
    {
        public List<ExportAnswer> Answers { get; set; }

        public string GetString(int number)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Text);
            stringBuilder.Append(Environment.NewLine);
            const string answers = "ABCDEFGHIJ";
            var pos = 0;
            foreach (var answer in Answers)
            {
                stringBuilder.AppendFormat("{0})\u00A0{1}. ", answers[pos++], answer.Text);
            }
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            return stringBuilder.ToString();
        }
    }
}
