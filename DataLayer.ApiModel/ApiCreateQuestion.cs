using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ApiModel
{
    public class ApiCreateQuestion
    {
        public string Text { get; set; }
        public int Complexity { get; set; }
        public Guid OwnerId { get; set; }
        public string Tags { get; set; }
        public List<ApiCreateAnswer> Answers { get; set; }
    }
}
