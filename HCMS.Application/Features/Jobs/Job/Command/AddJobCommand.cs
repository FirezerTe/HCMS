using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Features.Jobs
{
    public class AddJobCommand:IRequest<int>
    {
        public int JobTitleId {get; set;}
        public int BusinessUnitId { get; set;}
    }
}
