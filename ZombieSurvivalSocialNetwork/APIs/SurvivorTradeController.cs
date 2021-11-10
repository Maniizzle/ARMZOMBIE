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
        public async Task<IActionResult> RequestTrade([FromBody] RequestTradeCommand requestTrade)
        {
            return CreatedAtAction(nameof(RequestTrade), await Mediator.Send(requestTrade));
        }

        //[HttpPost("confirmTrade")]
        //[ProducesResponseType(typeof(Response<object>), 201)]
        //[ProducesResponseType(typeof(Response<object>), 400)]
        //[ProducesResponseType(typeof(Response<object>), 500)]
        //public async Task<IActionResult> ConfirmTrade([FromBody] ConfirmTradeCommand confirmTrade)
        //{
        //    return CreatedAtAction(nameof(RequestTrade), await Mediator.Send(confirmTrade));
        //}
    }
}
