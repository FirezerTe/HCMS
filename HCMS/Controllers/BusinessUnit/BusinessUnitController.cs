using HCMS.Application.Features.BusinessUnits;
using HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.API.Controllers.BusinessUnits
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : BaseController<BusinessUnitController>
    {

        [HttpPost("CreateBusinessUnit", Name = "CreateBusinessUnit")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> CreateBusinessUnit([FromBody] CreateBusinessUnitCommand command)
        {
            var parValueId = await mediator.Send(command);
            return Ok(parValueId);
        }
        [HttpGet("all", Name = "GetAllBusinessUnits")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<BusinessUnitDto>>> GetAllBusinessUnits()
        {
            var searchResult = await mediator.Send(new GetBusinessUnitsQuery());
            return searchResult;
        }

    }
}
