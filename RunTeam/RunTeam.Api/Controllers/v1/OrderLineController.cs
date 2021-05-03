using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunTeam.Application.Features.OrderLines.Commands.Create;
using RunTeam.Application.Features.OrderLines.Commands.DeleteById;
using RunTeam.Application.Features.OrderLines.Commands.Update;
using RunTeam.Application.Features.OrderLines.Queries.GetAll;
using RunTeam.Application.Features.OrderLines.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTeam.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OrderLineController : BaseApiController
    {
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetOrderLineByIdQuery { Id = id }));
        }

        // GET api/<controller>/GetByOrderId/3
        [HttpGet("GetLinesByOrderId/{orderId}")]
        public async Task<IActionResult> GetLinesByOrderId(int orderId)
        {
            return Ok(await Mediator.Send(new GetAllLinesByOrderIdQuery { OrderId = orderId }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreateOrderLineCommand command)
        {
            var result = Ok(await Mediator.Send(command));
            return result;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateOrderLineCommand command)
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
            return Ok(await Mediator.Send(new DeleteOrderLineByIdCommand { Id = id }));
        }
    }
}
