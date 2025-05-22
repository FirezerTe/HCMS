using HCMS.Application.Features.Jobs;
using HCMS.Application.Features.Jobs.JobCatagories;
using HCMS.Application.Features.Jobs.JobGrades;
using HCMS.Application.Features.Jobs.JobTitles;
using HCMS.Domain.Job;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace HCMS.API.Controllers.JobController
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class JobController:BaseController<JobController>
    {
 
        [HttpPost("AddJobGrade",Name ="AddJobGrade")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<string>> AddJobGrade([FromBody]AddJobGradeCommand command)
        {
            var jobGrade=await mediator.Send(command);
            return (jobGrade);
        }
        [HttpPost("AddJobTitle", Name = "AddJobTitle")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> AddJobTitle([FromBody] AddJobTitleCommand command)
        {
            var jobGrade = await mediator.Send(command);
            return (jobGrade);
        }
        [HttpPost("AddJobCatagory", Name = "AddJobCatagory")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> AddJobCatagory([FromBody] AddJobCatagoryCommand command)
        {
            var jobGrade = await mediator.Send(command);
            return (jobGrade);
        }
        [HttpGet("allJobTitles", Name = "GetAllJobTitle")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<JobTitleDto>>> GetAllJobTitle()
        {
            var searchResult = await mediator.Send(new GetJobTitleQuery());
            return searchResult;
        }
        [HttpGet("allJobGrades", Name = "GetAllJobGrade")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<JobGrade>>> GetAllJobGrade()
        {
            var searchResult = await mediator.Send(new GetJobGradeQuery());
            return searchResult;
        }
        [HttpGet("allJobCatagory", Name = "GetAllJobCatagory")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<JobCatagory>>> GetAllJobCatagory()
        {
            var searchResult = await mediator.Send(new GetJobCatagoryQuery());
            return searchResult;
        }

        [HttpPost("AddJob", Name = "AddNewJob")]
        public async Task<ActionResult<int>> AddNewJob([FromBody] AddJobCommand command)
        {
            var newJob= await mediator.Send(command);
            return newJob;
        }
        [HttpGet("GetAllJob" ,Name ="GetAllJobList")]
        public async Task<ActionResult<List<JobDto>>> GetAllJobList()
        {
            var jobList= await mediator.Send(new GetAllJobQuery());
            return jobList;
        }
    };
}
