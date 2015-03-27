using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ApiModel
{
    public class ApiCreateTest
    {
        public string Description { get; set; }

        public List<Guid> Questions { get; set; }
    }
}
