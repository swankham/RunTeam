using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunTeam.Application.Features.OrderHeads.Commands.Create;
using RunTeam.Application.Features.OrderHeads.Commands.DeleteById;
using RunTeam.Application.Features.OrderHeads.Commands.Update;
using RunTeam.Application.Features.OrderHeads.Queries.GetAll;
using RunTeam.Application.Features.OrderHeads.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTeam.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OrderHeadController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllOrderHeadsQuery()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetOrderHeadByIdQuery { Id = id }));
        }

        // GET api/<controller>/5
        [HttpGet("GetByUser/{userId}")]
        public async Task<IActionResult> GetByUser(string userId)
        {
            return Ok(await Mediator.Send(new GetOrderHeadsByUserIdQuery { userId = userId }));
        }

        // GET api/<controller>/5
        [HttpGet("GetByEvent/{eventId}")]
        public async Task<IActionResult> GetByEvent(int eventId)
        {
            return Ok(await Mediator.Send(new GetOrderHeadsByEventIdQuery { eventId = eventId }));
        }

        // GET api/<controller>/5
        [HttpGet("GetByStatus/{status}")]
        public async Task<IActionResult> GetByStatus(int status)
        {
            return Ok(await Mediator.Send(new GetOrderHeadsByStatusQuery { status = status }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreateOrderHeadCommand command)
        {
            var result = Ok(await Mediator.Send(command));
            return result;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateOrderHeadCommand command)
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
            return Ok(await Mediator.Send(new DeleteOrderHeadByIdCommand { Id = id }));
        }
    }
}
