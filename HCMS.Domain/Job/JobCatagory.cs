using HCMS.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Job
{
    public class JobCatagory
    {
        public JobCatagoryEnum Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
