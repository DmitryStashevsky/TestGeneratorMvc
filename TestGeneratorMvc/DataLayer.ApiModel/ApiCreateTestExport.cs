using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ApiModel
{
    public class ApiCreateTestExport
    {
        public int NumberOfVariants { get; set; }
        public Guid TestId { get; set; }
    }
}
