using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ApiModel
{
    public class ApiShowAnswerWithValue : ApiBaseEntity
    {
        public bool IsCorrect { get; set; }

        public string Text { get; set; }
    }
}
