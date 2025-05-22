using HCMS.API.Dto;
using HCMS.Application.Features.BusinessUnits;
using HCMS.Application.Features.BusinessUnits.Queries;
using HCMS.Application.Features.Jobs.JobCatagories;
using HCMS.Application.Features.Jobs.JobGrades;
using HCMS.Application.Features.Jobs.JobTitles;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.API.Controllers.LookupController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController:BaseController<LookupController>
    {
 
        [HttpGet("all")]
        public async Task<LookupDto> GetAllLookups()
        {
           var jobTitles= await mediator.Send(new GetJobTitleQuery());
            var jobGrades= await mediator.Send(new GetJobGradeQuery());
            var jobCatagories=await mediator.Send(new GetJobCatagoryQuery());
            var businessUnits= await mediator.Send(new GetBusinessUnitsQuery());
            var businessUnitTypes = await mediator.Send(new GetBusinessUnitTypeQuery());

            return new LookupDto
            {
                JobTitles= jobTitles,
                JobGrades= jobGrades,
                JobCatagories= jobCatagories,
                BusinessUnits= businessUnits,
                BusinessUnitTypes= businessUnitTypes

            };
        }
    }
}
