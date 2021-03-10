using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunTeam.Application.Features.Contacts.Commands.Create;
using RunTeam.Application.Features.Contacts.Commands.DeleteById;
using RunTeam.Application.Features.Contacts.Commands.Update;
using RunTeam.Application.Features.Contacts.Queries.GetAll;
using RunTeam.Application.Features.Contacts.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTeam.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ContactAddressController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllContactsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllContactsQuery()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetContactByIdQuery { Id = id }));
        }

        // GET api/<controller>/GetBySrm/3
        [HttpGet("GetBySrm/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            return Ok(await Mediator.Send(new GetContactByUserIdQuery { UserId = userId }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateContactCommand command)
        {
            var result = Ok(await Mediator.Send(command));
            return result;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateContactCommand command)
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
            return Ok(await Mediator.Send(new DeleteContactByIdCommand { Id = id }));
        }
    }
}
