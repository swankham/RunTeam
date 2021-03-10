using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunTeam.Application.Features.Countries.Commands.Create;
using RunTeam.Application.Features.Countries.Commands.DeleteById;
using RunTeam.Application.Features.Countries.Commands.Update;
using RunTeam.Application.Features.Countries.Queries.GetAll;
using RunTeam.Application.Features.Countries.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTeam.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CountryController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCountriesParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllCountriesQuery()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCountryByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreateCountryCommand command)
        {
            var result = Ok(await Mediator.Send(command));
            return result;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateCountryCommand command)
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
            return Ok(await Mediator.Send(new DeleteCountryByIdCommand { Id = id }));
        }
    }
}