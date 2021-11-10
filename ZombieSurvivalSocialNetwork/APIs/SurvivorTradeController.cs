using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Features.SurvivorTrades;
using ZombieSurvivalSocialNetwork.Core.Application.Wrappers;

namespace ZombieSurvivalSocialNetwork.APIs
{
    public class SurvivorTradeController : BaseApiController
    {

        [HttpPost("requestTrade")]
        [ProducesResponseType(typeof(Response<object>), 201)]
        [ProducesResponseType(typeof(Response<object>), 400)]
        [ProducesResponseType(typeof(Response<object>), 500)]
        public async Task<IActionResult> RequestTrade([FromBody] RequestTradeCommand addsurvivorModel)
        {
            return CreatedAtAction(nameof(RequestTrade), await Mediator.Send(addsurvivorModel));
        }
    }
}
