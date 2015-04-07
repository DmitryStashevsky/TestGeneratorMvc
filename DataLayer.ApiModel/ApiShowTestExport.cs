using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ApiModel
{
    public class ApiShowTestExport : ApiBaseEntity
    {
        public string VirtualPath { get; set; }
        public int NumberOfVariants { get; set; }
        public DateTime Created { get; set; }
    }
}
