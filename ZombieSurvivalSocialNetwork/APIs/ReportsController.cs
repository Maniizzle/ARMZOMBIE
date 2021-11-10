using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Features.Reports.Queries;
using ZombieSurvivalSocialNetwork.Core.Application.Wrappers;

namespace ZombieSurvivalSocialNetwork.APIs
{
    [Route("api/reports")]
    [ApiController]

    public class ReportsController:BaseApiController
    {

        [HttpGet()]
        [ProducesResponseType(typeof(Response<object>), 200)]
        [ProducesResponseType(typeof(Response<object>), 400)]
        [ProducesResponseType(typeof(Response<object>), 500)]
        public async Task<IActionResult> GetReports()
        {
            
            return Ok(await Mediator.Send(new GenerateReportQuery()));
        }
    }
}
