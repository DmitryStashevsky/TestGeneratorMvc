using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ApiModel
{
    public class ApiShowQuestionWithUser : ApiBaseEntity
    {
        public string Text { get; set; }
        public int? Rating { get; set; }
        public int Complexity { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string Tags { get; set; }
        public bool IsValid { get; set; }
        public ApiShowUser User { get; set; }
    }
}
