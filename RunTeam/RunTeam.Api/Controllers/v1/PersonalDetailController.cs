using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunTeam.Application.Features.PersonalDetails.Commands.Create;
using RunTeam.Application.Features.PersonalDetails.Commands.DeleteById;
using RunTeam.Application.Features.PersonalDetails.Commands.Update;
using RunTeam.Application.Features.PersonalDetails.Queries.GetAll;
using RunTeam.Application.Features.PersonalDetails.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTeam.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PersonalDetailController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPersonalDetailsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllPersonalDetailsQuery()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPersonalDetailByIdQuery { Id = id }));
        }

        // GET api/<controller>/GetBySrm/3
        [HttpGet("GetBySrm/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            return Ok(await Mediator.Send(new GetPersonalDetailByUserIdQuery { UserId = userId }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreatePersornalDetailCommand command)
        {
            var result = Ok(await Mediator.Send(command));
            return result;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdatePersonalDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePersonalDetailByIdCommand { Id = id }));
        }
    }
}
