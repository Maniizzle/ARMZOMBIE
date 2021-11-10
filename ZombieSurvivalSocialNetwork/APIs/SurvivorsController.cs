using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHOPRURETAIL.Application.Features.Customers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Features.Survivors.Commands;
using ZombieSurvivalSocialNetwork.Core.Application.Interfaces;
using ZombieSurvivalSocialNetwork.Core.Application.Wrappers;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;

namespace ZombieSurvivalSocialNetwork.APIs
{
    [Route("api/survivors")]
    [ApiController]

    public class SurvivorsController: BaseApiController
    {
        private readonly IGenericRepositoryAsync<Survivor> _survivorRepo;

        public SurvivorsController(IGenericRepositoryAsync<Survivor> survivorRepo)
        {
            _survivorRepo = survivorRepo;
        }

        [HttpPost("addsurvivor")]
        [ProducesResponseType(typeof(Response<object>), 201)]
        [ProducesResponseType(typeof(Response<object>), 400)]
        [ProducesResponseType(typeof(Response<object>), 500)]
        public async Task<IActionResult> AddSurvivor([FromBody] AddSurvivorCommand addsurvivorModel)
        {
            return CreatedAtAction(nameof(AddSurvivor), await Mediator.Send(addsurvivorModel));
        }

        [HttpPut("updatesurvivorlocation")]
        [ProducesResponseType(typeof(Response<object>), 204)]
        [ProducesResponseType(typeof(Response<object>), 400)]
        [ProducesResponseType(typeof(Response<object>), 500)]
        public async Task<IActionResult> UpdateSurvivorLocation([FromBody] UpdateSurvivorLocationCommand model)
        {
            await Mediator.Send(model);
            return NoContent();
        }

        [HttpPost("reportsurvivor")]
        [ProducesResponseType(typeof(Response<object>), 204)]
        [ProducesResponseType(typeof(Response<object>), 400)]
        [ProducesResponseType(typeof(Response<object>), 500)]
        public async Task<IActionResult> FlagSurvivor([FromBody] FlagSurvivorCommand model)
        {
            return CreatedAtAction(nameof(UpdateSurvivorLocation), await Mediator.Send(model));
        }
       
        [HttpGet("getsurvivors")]
        [ProducesResponseType(typeof(Response<object>), 204)]
        [ProducesResponseType(typeof(Response<object>), 400)]
        [ProducesResponseType(typeof(Response<object>), 500)]
        public async Task<IActionResult> GetSurvivors()
        {
            
            
            return Ok(await Mediator.Send(new GetSurvivorsQuery()));
        }

        [HttpGet("getsurvivor/{id}")]
        [ProducesResponseType(typeof(Response<object>), 204)]
        [ProducesResponseType(typeof(Response<object>), 400)]
        [ProducesResponseType(typeof(Response<object>), 500)]
        public async Task<IActionResult> GetSurvivors(int id)
        {
          var survivor=  await _survivorRepo.GetByIdAsync(id);

            return Ok(survivor);
        }
    }
}
