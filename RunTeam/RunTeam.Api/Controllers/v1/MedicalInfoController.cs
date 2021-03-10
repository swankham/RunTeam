using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunTeam.Application.Features.MedicalInfos.Commands.Create;
using RunTeam.Application.Features.MedicalInfos.Commands.DeleteById;
using RunTeam.Application.Features.MedicalInfos.Commands.Update;
using RunTeam.Application.Features.MedicalInfos.Queries.GetAll;
using RunTeam.Application.Features.MedicalInfos.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTeam.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MedicalInfoController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllMedicalInfosParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllMedicalInfosQuery()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetMedicalInfoByIdQuery { Id = id }));
        }

        // GET api/<controller>/GetBySrm/3
        [HttpGet("GetByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            return Ok(await Mediator.Send(new GetMedicalInfoByUserIdQuery { UserId = userId }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateMedicalInfoCommand command)
        {
            var result = Ok(await Mediator.Send(command));
            return result;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateMedicalInfoCommand command)
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
            return Ok(await Mediator.Send(new DeleteMedicalInfoByIdCommand { Id = id }));
        }
    }
}
